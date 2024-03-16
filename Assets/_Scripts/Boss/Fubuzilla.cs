using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fubuzilla : Boss
{
    protected override void Awake()
    {
        base.Awake();
        MaxHP = 1;
        ATK = 25;
        Speed = 2;
        HP = MaxHP;
    }
}
