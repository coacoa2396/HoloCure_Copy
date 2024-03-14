using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : Monster
{
    protected override void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        spriter = GetComponentInChildren<SpriteRenderer>();
        animator = GetComponent<Animator>();
        scene = GameObject.FindGameObjectWithTag("GameScene").GetComponent<GameScene>();
        PlayerController player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        target = player.GetComponent<Rigidbody2D>();

        MaxHP = 1;
        ATK = 25;
        Speed = 2;
        isLive = true;
        HP = MaxHP;
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
        StartCoroutine(DieAnim());
        

        //if (spriter.flipX)
        //{
        //    animator.SetTrigger("Dead_R");
        //}
        //else
        //{
        //    animator.SetTrigger("Dead_L");
        //}
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
}
