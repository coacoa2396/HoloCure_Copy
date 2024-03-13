using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BLBook : Bullet
{
    public float damage;

    protected override void Awake() { }

    protected override void Update() { }
    

    public void Init(float damage, int per)
    {
        this.damage = damage;
        this.per = per;
    }
}
