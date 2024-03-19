using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmePistol : RangedWeapon, IActiveCheck
{
    protected override void Awake()
    {
        base.Awake();
        bulletCount = 3;
        interval = 2f;
    }

    protected override void Update()
    {
        timer += Time.deltaTime;

        if (timer > interval)
        {
            timer = 0f;
            Manager.Sound.PlaySFX("AmePistol");
            StartCoroutine(Fire());
        }
    }
}
