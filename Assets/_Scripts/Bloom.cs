using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bloom : Monster
{
    private void Awake()
    {
        MaxHP = 50;
        HP = 50;
        ATK = 3;
    }

    protected override void TakeDamage(int damage)
    {
        
    }

    protected override void Tracing(PlayerController player)
    {
        base.Tracing(player);
    }

    protected override void Hit(PlayerController player)
    {
        base.Hit(player);
    }

    protected override void OnTriggerStay2D(Collider2D collision)
    {
        base.OnTriggerStay2D(collision);
    }
}
