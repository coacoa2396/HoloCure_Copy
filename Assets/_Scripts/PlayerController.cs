using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour, IDamagable
{
    public Vector2 inputVec;

    [Header("Spec")]
    [SerializeField] float speed;
    [SerializeField] int maxHp;
    [SerializeField] int hp;

    [SerializeField] public int HP { get { return hp; } set { hp = value; } }
    [SerializeField] public int MaxHP { get { return maxHp; } set { maxHp = value; } }

    [Header("Component")]
    [SerializeField] Rigidbody2D rigid;
    [SerializeField] SpriteRenderer spriter;
    [SerializeField] Animator animator;

    [Header("Event")]
    [SerializeField] public UnityEvent OnFired;
    [SerializeField] public UnityEvent OnDied;

    public Vector2 aimDir;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        spriter = GetComponentInChildren<SpriteRenderer>();
        animator = GetComponent<Animator>();

        HP = 20;

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
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (!(collision.gameObject.transform.tag == "Monster"))
            return;

        
        Monster monster = collision.gameObject.GetComponent<Monster>();

        float timer = 1.5f;
        timer += Time.deltaTime;
        if (timer > 1.5f)
        {
            TakeDamage(monster.ATK);
            DamagedEffect(monster.transform.position);
        }
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

    public void Die()
    {
        
        OnDied?.Invoke();
    }
}
