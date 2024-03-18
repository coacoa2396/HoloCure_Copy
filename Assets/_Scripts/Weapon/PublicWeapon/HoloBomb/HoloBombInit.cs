using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoloBombInit : RangedWeapon, IActiveCheck
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
            
            StartCoroutine(Fire());
        }
    }

    protected override IEnumerator Fire()
    {
        for (int i = 0; i < bulletCount; i++)
        {
            PooledObject instance = Manager.Pool.GetPool(bullet, transform.position, Quaternion.identity);
            
            yield return new WaitForSeconds(0.2f);
        }

    }
}
