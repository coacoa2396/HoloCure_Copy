using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmePistol : RangedWeapon
{
    protected override void Awake()
    {
        base.Awake();
        bulletCount = 3;
        interval = 2;
    }

    protected override void Update()
    {
        base.Update();
    }
}
