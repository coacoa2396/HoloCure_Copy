using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : PooledObject, IDamagable
{
    [Header("Spec")]
    [SerializeField] int hp;
    [SerializeField] int maxHp;
    [SerializeField] int atk;
    [SerializeField] int speed;

    public int HP { get { return hp; } set { hp = value; } }
    public int MaxHP { get { return maxHp; } set { maxHp = value; } }
    public int ATK { get { return atk; } set { atk = value; } }
    public int Speed { get { return speed; } set { speed = value; } }

    [SerializeField] protected bool isLive;

    [Header("Component")]
    [SerializeField] protected Rigidbody2D rigid;
    [SerializeField] protected Rigidbody2D target;
    [SerializeField] protected SpriteRenderer spriter;



    protected void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        spriter = GetComponentInChildren<SpriteRenderer>();
        MaxHP = 400;
        ATK = 2;
    }

    private void FixedUpdate()
    {
        Tracing(target);
    }


    protected void LateUpdate()
    {
        spriter.flipX = target.position.x < rigid.position.x;
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

        Debug.Log("���� �ǰ�");

        Weapon weapon = collision.gameObject.GetComponent<Weapon>();

        TakeDamage(weapon.atk);
        DamagedEffect(weapon.transform.position);
    }

    protected void Tracing(Rigidbody2D target)
    {
        if (isLive == false)
            return;

        Vector2 targetDir = (target.transform.position - transform.position).normalized;
        Vector2 nextDir = targetDir * Speed * Time.fixedDeltaTime;

        
        rigid.MovePosition(rigid.position + nextDir);

    }

    public void TakeDamage(int damage)
    {
        hp -= damage;

        if (hp > 0)
            return;

        Die();
    }

    public void DamagedEffect(Vector2 targetPos)
    {
        spriter.color = new Color(1, 1, 1, 0.4f);    // �÷��� ����(���İ�) ����

        Vector2 knockbackDir = ((Vector2)transform.position - targetPos).normalized;    // ƨ�ܳ����� ����
        //rigid.AddForce(knockbackDir * 5, ForceMode2D.Impulse);       // ���ۿ����� ƨ�ܳ����� ��� ����
        rigid.transform.Translate(knockbackDir * 0.12f);

        Invoke("OffDamaged", 0.05f);
    }

    void OffDamaged()
    {
        spriter.color = new Color(1, 1, 1, 1);   // ���� ������� ����
    }

    protected void Die()
    {
        gameObject.SetActive(false);
    }
}
