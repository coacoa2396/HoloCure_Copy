using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmePistol : RangedWeapon
{
    [SerializeField] Transform firePoint;

    private void Awake()
    {
        atk = 10;
        speed = 7;
        bulletCount = 4;
    }
}
