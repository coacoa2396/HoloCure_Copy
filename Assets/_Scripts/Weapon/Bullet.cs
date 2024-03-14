using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : Weapon
{
    
    [SerializeField] public int per; // 관통하는 수
    [SerializeField] protected float force;
    [SerializeField] protected Rigidbody2D rigid;

    protected virtual void Awake()
    {
        
    }

    protected virtual void Update()
    {
                
    }

    protected virtual void OnEnable()
    {
        if (gameObject != null)
            StartCoroutine(Setfalse());        
    }

    protected IEnumerator Setfalse()
    {
        yield return new WaitForSeconds(10f);
        gameObject.SetActive(false);
    }

    public void Init(int atk, int per)
    {
        this.atk = atk;
        this.per = per;        
    }
}
