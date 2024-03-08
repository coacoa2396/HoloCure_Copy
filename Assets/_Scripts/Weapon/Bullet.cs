using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : PooledObject
{
    [SerializeField] protected int atk;
    [SerializeField] protected int count; // 관통하는 수
    [SerializeField] protected float force;

    [SerializeField] Rigidbody2D rb;

    protected virtual void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    protected virtual void Update()
    {
        rb.velocity = transform.right * force;
        
        if (gameObject != null)
            StartCoroutine(Setfalse());
    }

    IEnumerator Setfalse()
    {
        yield return new WaitForSeconds(5f);
        gameObject.SetActive(false);
    }
}
