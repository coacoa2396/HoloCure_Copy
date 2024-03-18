using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public Vector2 inputVec;

    [Header("Spec")]
    [SerializeField] public int level;
    [SerializeField] public int needEXP;
    [SerializeField] public int curEXP;
    [SerializeField] public int curCoin;
    [SerializeField] float speed;
    [SerializeField] int maxHp;
    [SerializeField] int hp;

    [SerializeField] public int HP { get { return hp; } set { hp = value; } }
    [SerializeField] public int MaxHP { get { return maxHp; } set { maxHp = value; } }

    [Header("Component")]
    [SerializeField] Rigidbody2D rigid;
    [SerializeField] public SpriteRenderer spriter;
    [SerializeField] Animator animator;
    [SerializeField] GameObject ItemGetter;
    [SerializeField] GameObject[] activeFalse;
    [SerializeField] public Sprite personalWeaponSprite;

    [Header("Event")]    
    [SerializeField] public UnityEvent OnDied;

    public Vector2 aimDir;


    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        spriter = GetComponentInChildren<SpriteRenderer>();
        animator = GetComponent<Animator>();
        ItemGetter = GameObject.FindGameObjectWithTag("ItemGetter");

        level = 1;
        MaxHP = 20;
        curEXP = 0;
        needEXP = 100;
        curCoin = 0;
        HP = MaxHP;
    }

    private void Start()
    {
        for (int i = 0; i < activeFalse.Length; i++)
        {
            activeFalse[i].gameObject.SetActive(false);
        }
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void LateUpdate()
    {
        animator.SetFloat("Speed", inputVec.magnitude);

        if (inputVec.x != 0)
        {
            spriter.flipX = inputVec.x < 0;
        }

        LevelCheck();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (!(collision.gameObject.transform.tag == "Monster" ||
            collision.gameObject.transform.tag == "BossSkill" ||
            collision.gameObject.transform.tag == "Item"))
            return;

        Debug.Log(collision.gameObject.name);

        if (collision.gameObject.transform.tag == "Monster")
        {
            Debug.Log("몬스터한테 맞음");
            Monster monster = collision.gameObject.GetComponent<Monster>();

            float timer = 1.5f;
            timer += Time.deltaTime;
            if (timer > 1.5f)
            {
                timer = 0f;
                TakeDamage(monster.ATK);
                DamagedEffect(monster.transform.position);
            }
        }

        if (collision.gameObject.transform.tag == "BossSkill")
        {
            Debug.Log("보스스킬에 맞음");
            BossSkill bossSkill = collision.gameObject.GetComponent<BossSkill>();

            float timer = 1.5f;
            timer += Time.deltaTime;
            if (timer > 1.5f)
            {
                timer = 0f;
                TakeDamage(bossSkill.ATK);
                DamagedEffect(bossSkill.transform.position);
            }
        }

        StartCoroutine(IInvincible());
    }

    void LevelCheck()
    {
        if (curEXP < needEXP)
            return;

        LevelUp();
    }

    void LevelUp()
    {
        curEXP = curEXP - needEXP;
        needEXP += (int)(needEXP * 0.2);
        level++;
    }

    void Move()
    {
        Vector2 nextVec = inputVec.normalized * speed * Time.fixedDeltaTime;

        rigid.MovePosition(rigid.position + nextVec);
    }

    void OnMove(InputValue value)
    {
        Vector2 input = value.Get<Vector2>();
        inputVec.x = input.x;
        inputVec.y = input.y;
    }

    void OnAim(InputValue value)
    {
        Vector2 input = value.Get<Vector2>();
        Vector2 pos = Camera.main.ScreenToWorldPoint(input);

        aimDir = pos - (Vector2)transform.position;
        aimDir.Normalize();
    }

    public void TakeDamage(int damage)
    {
        Debug.Log("아야");
        
        HP -= damage;

        if (HP > 0)
            return;

        Die();
    }

    public void DamagedEffect(Vector2 targetPos)
    {
        spriter.color = new Color(1, 1, 1, 0.4f);    // 컬러와 투명도(알파값) 적용        

        Invoke("OffDamaged", 0.3f);
    }

    void OffDamaged()
    {
        spriter.color = new Color(1, 1, 1, 1);   // 투명도 원래대로 변경
    }

    IEnumerator IInvincible()
    {
        gameObject.layer = 9;
        //Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Player"), LayerMask.NameToLayer("Monster"), true);
        //Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Player"), LayerMask.NameToLayer("BossSkill"), true);

        yield return new WaitForSeconds(0.5f);

        //Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Player"), LayerMask.NameToLayer("Monster"), false);
        //Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Player"), LayerMask.NameToLayer("BossSkill"), false);

        gameObject.layer = 6;
    }

    public void Die()
    {

        OnDied?.Invoke();
    }
}
