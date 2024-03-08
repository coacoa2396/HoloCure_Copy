using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmeBullet : Bullet
{
    protected override void Awake()
    {
        base.Awake();
        atk = 10;
        count = 2;
        force = 15;
    }

    protected override void Update()
    {
        base.Update();
    }
}
