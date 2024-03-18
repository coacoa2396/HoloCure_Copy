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
        base.Update();
    }
}
