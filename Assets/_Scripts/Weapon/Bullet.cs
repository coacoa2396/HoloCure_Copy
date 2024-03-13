using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : Weapon
{
    
    [SerializeField] public int per; // 관통하는 수
    [SerializeField] protected float force;
    [SerializeField] Rigidbody2D rigid;

    protected virtual void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    protected virtual void Update()
    {
        rigid.velocity = transform.right * force;
        
        if (gameObject != null)
            StartCoroutine(Setfalse());
    }

    IEnumerator Setfalse()
    {
        yield return new WaitForSeconds(5f);
        gameObject.SetActive(false);
    }

    public void Init(int atk, int per)
    {
        this.atk = atk;
        this.per = per;        
    }
}
