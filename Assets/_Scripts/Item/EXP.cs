using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EXP : Item
{
    [SerializeField] EXP expPrefab;
    [SerializeField] SpriteRenderer spriter;
    [SerializeField] Sprite[] sprites;
    [SerializeField] Rigidbody2D rigid;

    public int amount;
    [SerializeField] int level;
    [SerializeField] float speed;

    bool isTriger;


    private List<Dictionary<string, object>> csv;

    private void Awake()
    {
        csv = CSVReader.Read("Data/CSV/EXP_Design");
        expPrefab = GameObject.FindGameObjectWithTag("GameScene").GetComponent<GameScene>().items[0].GetComponent<EXP>();
        spriter = GetComponent<SpriteRenderer>();
        rigid = GetComponent<Rigidbody2D>();

        Init(0);
    }


    protected override void OnEnable()
    {
        base.OnEnable();
        isTriger = false;
    }

    private void FixedUpdate()
    {
        if (!isTriger)
            return;

        MovePlayer();
    }

    protected override void OnTriggerEnter2D(Collider2D collision)
    {

        if (!(collision.transform.tag == "Player" ||
            collision.transform.tag == "ItemGetter" ||
            collision.transform.tag == "EXP"))
            return;


        if (collision.transform.tag == "ItemGetter")
        {
            isTriger = true;
        }

        if (collision.transform.tag == "Player")
        {            
            player.curEXP += amount;
            base.OnTriggerEnter2D(collision);
        }

        if (collision.transform.tag == "EXP")
        {

            EXP collEXP = collision.transform.GetComponent<EXP>();

            // 합쳐져서 다음 경험치를 만드는 로직
            if (!(level == collEXP.level) || level == 5)        // 현재 경험치의 레벨과 같지 않거나, 만렙일 경우 리턴
                return;


            // 중간점에서 생성해야 하므로 중간지점 좌표 구하기
            Vector2 nextPos = new Vector2((transform.position.x + collEXP.transform.position.x) / 2,
                (transform.position.y + collEXP.transform.position.y) / 2);



            if (gameObject.GetInstanceID() < collEXP.gameObject.GetInstanceID())
            {
                collEXP.gameObject.SetActive(false);
                EXP nextEXP = Manager.Pool.GetPool(expPrefab, nextPos, transform.rotation).GetComponent<EXP>();
                nextEXP.Init(level + 1);
                gameObject.SetActive(false);
            }
            else
            {
                gameObject.SetActive(false);
            }
        }
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
        gameObject.name = (string)csv[level]["name"];
        amount = (int)csv[level]["amount"];
        this.level = level;
        spriter.sprite = sprites[level];
    }
}
