using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : PooledObject
{
    int hp;
    int maxHp;
    int atk;

    [Header("Spec")]
    [SerializeField] int speed;
    [SerializeField] public int HP { get { return hp; } set { hp = value; } }
    [SerializeField] public int MaxHP { get { return maxHp; } set { maxHp = value; } }
    [SerializeField] public int ATK { get { return atk; } set { atk = value; } }
    [SerializeField] public int Speed { get { return speed; } set { speed = value; } }

    [SerializeField] protected bool isLive;

    [Header("Component")]
    [SerializeField] protected Rigidbody2D rigid;
    [SerializeField] protected Rigidbody2D target;
    [SerializeField] protected SpriteRenderer spriter;



    protected void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        spriter = GetComponentInChildren<SpriteRenderer>();

    }

    private void FixedUpdate()
    {
        Tracing(target);
    }


    protected void LateUpdate()
    {
        spriter.flipX = target.position.x < rigid.position.x;
    }


    protected void OnTriggerStay2D(Collider2D collision)
    {
        if (!(collision.gameObject.transform.tag == "Player"))
            return;

        Rigidbody2D target = collision.gameObject.GetComponent<Rigidbody2D>();
        Hit(target);
    }

    private void OnEnable()
    {
        rigid = GetComponent<Rigidbody2D>();
        spriter = GetComponentInChildren<SpriteRenderer>();

        isLive = true;

        PlayerController player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        target = player.GetComponent<Rigidbody2D>();

        HP = MaxHP;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!(collision.gameObject.transform.tag == "Weapon"))
            return;

        // �������� �� �� �ִ� ������Ʈ�鿡�� IHitable ���� �������̽��� �������� �߰��ؼ� �����ϱ�
        // atk�� �������̽��δ� ������ �� ���� ������ �߻�Ŭ������ ���� ����ϱ�?
        // �ƴ� HitableŬ������ �ʿ䰡 ����
        // �������� ���� Ŭ������ �Ѿ˰� �ٰŸ������ �Ǿ��ְ� ���� �ش� Ŭ��������
        // Hit()�Լ��� ���� Ʈ���ſ��� üũ�� ���� ���Ϳ� ������ ������ TakeDamage�Լ��� �ߵ������ָ� ��
    }

    protected void Tracing(Rigidbody2D target)
    {
        if (isLive == false)
            return;

        Vector2 targetDir = (target.transform.position - transform.position).normalized;
        Vector2 nextDir = targetDir * Speed * Time.fixedDeltaTime;
        rigid.MovePosition(rigid.position + nextDir);

    }

    protected void Hit(Rigidbody2D target)
    {
        // �÷��̾����� TakeDamage �Լ� ���� �̵��ϱ�
    }

    protected void TakeDamage(int damage)
    {

    }

    protected void Die()
    {

    }
}
