using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PsychoAxeInit : RangedWeapon, IActiveCheck
{
    protected override void Awake()
    {
        base.Awake();

        bulletCount = 1;
        interval = 3f;
    }
       

    protected override void Update()
    {
        timer += Time.deltaTime;

        if (timer > interval)
        {
            timer = 0f;

            Manager.Sound.PlaySFX("PsychoAxe");
            StartCoroutine(Fire());
        }
    }
}
