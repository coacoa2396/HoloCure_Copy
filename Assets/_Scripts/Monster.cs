using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor.Animations;
using UnityEngine;

public class Monster : PooledObject, IDamagable
{
    [Header("Spec")]
    [SerializeField] int hp;
    [SerializeField] int maxHp;
    [SerializeField] int atk;
    [SerializeField] float speed;

    public int HP { get { return hp; } set { hp = value; } }
    public int MaxHP { get { return maxHp; } set { maxHp = value; } }
    public int ATK { get { return atk; } set { atk = value; } }
    public float Speed { get { return speed; } set { speed = value; } }

    [Header("Component")]
    [SerializeField] protected Rigidbody2D rigid;
    [SerializeField] protected Rigidbody2D target;
    [SerializeField] public SpriteRenderer spriter;
    [SerializeField] protected Animator animator;
    [SerializeField] protected GameObject anim;
    [SerializeField] protected GameScene scene;
    [SerializeField] protected EXP exp;
    [SerializeField] protected Coin coin;

    [SerializeField] protected int level;
    [SerializeField] protected bool isLive;

    private List<Dictionary<string, object>> csv;

    protected virtual void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        spriter = GetComponentInChildren<SpriteRenderer>();
        animator = GetComponent<Animator>();
        scene = GameObject.FindGameObjectWithTag("GameScene").GetComponent<GameScene>();
        exp = GameObject.FindGameObjectWithTag("GameScene").GetComponent<GameScene>().items[0].GetComponent<EXP>();
        coin = GameObject.FindGameObjectWithTag("GameScene").GetComponent<GameScene>().items[1].GetComponent<Coin>();
        csv = CSVReader.Read("Data/CSV/MonsterLevelDesign");
    }

    protected virtual void FixedUpdate()
    {

        Tracing(target);
    }


    protected virtual void LateUpdate()
    {
        spriter.flipX = target.position.x < rigid.position.x;
    }

    protected virtual void OnEnable()
    {
        rigid = GetComponent<Rigidbody2D>();
        spriter = GetComponentInChildren<SpriteRenderer>();

        isLive = true;

        PlayerController player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        target = player.GetComponent<Rigidbody2D>();

        if (scene.level < 20)
        {
            level = scene.level;
        }
        else
        {
            level = 20;
        }

        MaxHP = (int)csv[level]["hp"];
        Speed = (float)csv[level]["speed"];
        ATK = (int)csv[level]["atk"];

        HP = MaxHP;
    }

    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (!(collision.gameObject.transform.tag == "Weapon" || collision.gameObject.transform.tag == "ActiveCheck"))
            return;

        if (!isLive)
            return;

        Manager.Sound.PlaySFX("MonsterDamaged");

        Debug.Log("몬스터 피격");

        Weapon weapon = collision.gameObject.GetComponent<Weapon>();


        TakeDamage(weapon.atk);

        DamagedEffect(weapon.transform.position);
    }



    protected virtual void Tracing(Rigidbody2D target)
    {
        if (isLive == false)
            return;

        if (!((Vector2.Distance(transform.position, target.position)) < 0.1f))
        {
            Vector2 targetDir = (target.transform.position - transform.position).normalized;
            Vector2 nextDir = targetDir * Speed * Time.fixedDeltaTime;


            rigid.MovePosition(rigid.position + nextDir);
        }
    }

    public virtual void TakeDamage(int damage)
    {
        if (!isLive)
            return;

        Debug.Log("테이크데미지");
        hp -= damage;

        if (hp > 0)
            return;

        isLive = false;
        DropItem();
        StartCoroutine(DieAnim());
        anim.SetActive(true);

        if (spriter.flipX)
        {
            animator.SetTrigger("Dead_R");
        }
        else
        {
            animator.SetTrigger("Dead_L");
        }
    }

    protected virtual IEnumerator DieAnim()
    {
        yield return new WaitForSeconds(0.5f);
        Die();
    }

    public virtual void DamagedEffect(Vector2 targetPos)
    {
        Debug.Log("데미지이펙트");
        if (isLive == false)
            return;

        spriter.color = new Color(1, 1, 1, 0.4f);    // 컬러와 투명도(알파값) 적용

        Vector2 knockbackDir = ((Vector2)transform.position - targetPos).normalized;    // 튕겨나가는 방향
        //rigid.AddForce(knockbackDir * 5, ForceMode2D.Impulse);       // 반작용으로 튕겨나가는 모습 구현
        rigid.transform.Translate(knockbackDir * 0.12f);

        Invoke("OffDamaged", 0.05f);
    }

    void OffDamaged()
    {
        spriter.color = new Color(1, 1, 1, 1);   // 투명도 원래대로 변경
    }

    public virtual void Die()
    {
        scene.killCount++;
        gameObject.SetActive(false);
    }

    public virtual void DropItem()
    {
        int itemLevel = (int)(level / 4);
        if (itemLevel > 5)
            itemLevel = 5;

        // 경험치 아이템
        EXP initEXP = Manager.Pool.GetPool(exp, transform.position, transform.rotation).GetComponent<EXP>();
        initEXP.Init(itemLevel);

        // 코인
        // 코인은 항상 드랍 되는 것이 아니니까 확률을 잡고 일정확률일 경우에 드랍
        int ran = Random.Range(0, 100); // 0 ~ 99
        if (ran < 5)
        {
            Coin initCoin = Manager.Pool.GetPool(coin, transform.position, transform.rotation).GetComponent<Coin>();
            initCoin.Init(itemLevel);
        }
    }
}
