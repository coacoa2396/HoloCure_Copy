using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoloBomb : Bullet
{
    [SerializeField] PlayerController player;

    Animator animator;
    
    [SerializeField] float throwSpeed;
    [SerializeField] float decreaseSpeed;

    protected override void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        throwSpeed = 60f;
        decreaseSpeed = 2f;
    }

    protected override void Update()
    {
        Move();        
    }

    protected override void OnEnable()
    {        
        StartCoroutine(Explosion());
    }

    void Move()
    {
        transform.Translate(player.aimDir * throwSpeed * Time.deltaTime);

        throwSpeed -= decreaseSpeed;

        if (throwSpeed < 0 )
        {
            throwSpeed = 0;
        }
    }

    public void SetOff()
    {
        gameObject.SetActive(false);
    }

    IEnumerator Explosion()
    {
        yield return new WaitForSeconds(10f);

        animator.Play("HoloBomb");        
    }

    Collider2D[] colliders = new Collider2D[30];
    public void BoomAttack()
    {
        int size = Physics2D.OverlapCircleNonAlloc(transform.position, 4f, colliders);
        for (int i = 0; i < size; i++)
        {
            IDamagable damagable = colliders[i].GetComponent<IDamagable>();
            damagable?.TakeDamage(atk);
        }
    }
}
