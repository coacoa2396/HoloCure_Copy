using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeWeapon : Weapon
{
    public float range;
    public int count;       // 생성되는 수
    public float speed;

    [SerializeField] protected PooledObject weapon;

    public PooledObject Init(int atk, int count, Vector3 dir)
    {
        this.atk = atk;
        this.count = count;

        PooledObject instance = Manager.Pool.GetPool(weapon, dir, Quaternion.identity);

        return instance;
    }

}
