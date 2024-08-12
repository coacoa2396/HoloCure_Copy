using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EXP : Item
{
    public enum Mob { Normal, Boss }    // 누가 만든 경험치인가?

    [SerializeField] EXP expPrefab;
    [SerializeField] SpriteRenderer spriter;
    [SerializeField] Sprite[] sprites;
    [SerializeField] Rigidbody2D rigid;

    public int amount;
    [SerializeField] int level;
    [SerializeField] float speed;

    bool isTriger;
    bool isMerge;       // 합쳐지는지 여부 -> 기본은 false -> 일반몹은 바로 true, 보스몹은 1초뒤 true
    public Mob MobState;    // 몬스터의 노말, 보스 여부

    private List<Dictionary<string, object>> csv;

    private void Awake()
    {
        csv = CSVReader.Read("Data/CSV/EXP_Design");
        expPrefab = GameObject.FindGameObjectWithTag("GameScene").GetComponent<GameScene>().items[0].GetComponent<EXP>();
        spriter = GetComponent<SpriteRenderer>();
        rigid = GetComponent<Rigidbody2D>();

        isMerge = false;
        // Init(0);
    }

    private void Start()
    {
        if (MobState == Mob.Normal)
            isMerge = true;
        else
            StartCoroutine(IsMergeChanger());
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
            Manager.Sound.PlaySFX("GetEXP");
            base.OnTriggerEnter2D(collision);
        }

        if (collision.transform.tag == "EXP")
        {
            if (!isMerge)
                return;

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
                nextEXP.Init(level + 1, Mob.Normal);
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

    public void Init(int level, Mob state)
    {
        gameObject.name = (string)csv[level]["name"];
        amount = (int)csv[level]["amount"];
        this.level = level;
        spriter.sprite = sprites[level];
        MobState = state;
    }

    public IEnumerator IsMergeChanger()
    {
        yield return new WaitForSeconds(1f);

        isMerge = true;
    }
}
