using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmeBullet : Bullet
{
    protected override void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        atk = 10;
        per = 2;
        force = 15;
    }

    protected override void Update()
    {
        rigid.velocity = transform.right * force;
    }

    protected override void OnEnable()
    {
        base.OnEnable();
    }
}
