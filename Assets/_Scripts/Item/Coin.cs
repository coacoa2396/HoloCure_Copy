using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : Item
{
    [SerializeField] Rigidbody2D rigid;

    public int amount;
    [SerializeField] int level;
    [SerializeField] float speed;

    bool isTriger;

    private List<Dictionary<string, object>> csv;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        csv = CSVReader.Read("Data/CSV/Coin_Design");

        Init(0);
    }

    protected override void OnEnable()
    {
        base.OnEnable();
        isTriger = false;
    }

    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        if (!(collision.transform.tag == "Player" || collision.transform.tag == "ItemGetter"))
            return;


        if (collision.transform.tag == "ItemGetter")
        {
            isTriger = true;
        }

        if (collision.transform.tag == "Player")
        {
            player.curCoin += amount;
            base.OnTriggerEnter2D(collision);
        }
    }

    private void FixedUpdate()
    {
        if (!isTriger)
            return;

        MovePlayer();
    }

    void MovePlayer()
    {
        // 플레이어한테 날아가는 로직
        Vector2 targetDir = (player.transform.position - transform.position).normalized;
        Vector2 nextDir = targetDir * speed * Time.fixedDeltaTime;

        rigid.MovePosition(rigid.position + nextDir);
    }

    public void Init(int level)
    {
        this.level = (int)csv[level]["id"];
        name = (string)csv[level]["name"];
        amount = (int)csv[level]["amount"];
    }
}
