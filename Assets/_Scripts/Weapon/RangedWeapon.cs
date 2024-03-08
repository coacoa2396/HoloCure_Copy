using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedWeapon : MonoBehaviour
{          
    protected int bulletCount;
    protected float timer;
    protected float interval;

    [SerializeField] protected Bullet bullet;
    [SerializeField] protected PlayerController player;
    

    protected virtual void Awake()
    {
        player = GetComponentInParent<PlayerController>();        
    }

    protected virtual void Update()
    {
        timer += Time.deltaTime;

        if (timer > interval)
        {
            timer = 0f;
            PooledObject instance = Manager.Pool.GetPool(bullet, transform.position, Quaternion.identity);
            instance.transform.right = player.aimDir;
        }
    }
}
