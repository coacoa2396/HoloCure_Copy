using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bloom : Monster
{
    protected override void Awake()
    {
        base.Awake();
        MaxHP = 50;
        HP = 50;
        ATK = 3;
        Speed = 2;
    }

    private void FixedUpdate()
    {
        Tracing(target);    
    }

    protected override void LateUpdate()
    {
        base.LateUpdate();
    }

    protected override void TakeDamage(int damage)
    {
        
    }

    protected override void Tracing(Rigidbody2D target)
    {
        base.Tracing(target);
    }

    protected override void Hit(Rigidbody2D target)
    {
        base.Hit(target);
    }

    protected override void OnTriggerStay2D(Collider2D collision)
    {
        base.OnTriggerStay2D(collision);
    }
}
