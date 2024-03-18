using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Cinemachine.DocumentationSortingAttribute;

public class Boss : Monster
{
    [SerializeField] ItemBox box;

    protected override void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        spriter = GetComponentInChildren<SpriteRenderer>();
        animator = GetComponent<Animator>();
        scene = GameObject.FindGameObjectWithTag("GameScene").GetComponent<GameScene>();
        PlayerController player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        target = player.GetComponent<Rigidbody2D>();

        isLive = true;

    }

    protected override void OnEnable()
    {

    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();
    }

    protected override void LateUpdate()
    {
        base.LateUpdate();
    }

    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        base.OnTriggerEnter2D(collision);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.gameObject.name);
    }

    public override void TakeDamage(int damage)
    {
        HP -= damage;

        if (HP > 0)
            return;
        isLive = false;
        DropItem();
        StartCoroutine(DieAnim());
    }

    public override void DamagedEffect(Vector2 targetPos)
    {

    }

    protected override IEnumerator DieAnim()
    {
        yield return new WaitForSeconds(0.5f);
        Die();
    }

    public override void Die()
    {
        Destroy(gameObject);
    }

    public override void DropItem()
    {
        int itemLevel = (int)(level / 4);
        if (itemLevel > 5)
            itemLevel = 5;

        // 경험치 아이템
        for (int i = 0; i < 20; i++)
        {
            Vector2 ranPos = new Vector2(transform.position.x + Random.Range(-2f, 2f), transform.position.y + Random.Range(-2f, 2f));
            EXP initEXP = Manager.Pool.GetPool(exp, ranPos, transform.rotation).GetComponent<EXP>();
            initEXP.Init(itemLevel);
        }

        // 코인
        // 코인은 항상 드랍 되는 것이 아니니까 확률을 잡고 일정확률일 경우에 드랍
        for (int i = 0; i < 20; i++)
        {
            int ran = Random.Range(0, 100); // 0 ~ 99
            if (ran < 20)
            {
                Vector2 ranPos = new Vector2(transform.position.x + Random.Range(-2f, 2f), transform.position.y + Random.Range(-2f, 2f));
                Coin initCoin = Manager.Pool.GetPool(coin, ranPos, transform.rotation).GetComponent<Coin>();
                initCoin.Init(itemLevel);
            }
        }

        // 아이템 박스
        Manager.Pool.GetPool(box, transform.position, transform.rotation);
    }
}
