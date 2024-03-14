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
            Debug.Log("코루틴실행전");
            StartCoroutine(Fire());
        }
    }

    protected virtual IEnumerator Fire()
    {
        for (int i = 0; i < bulletCount; i++)
        {
            PooledObject instance = Manager.Pool.GetPool(bullet, transform.position, Quaternion.identity);
            
            instance.transform.right = player.aimDir;
            //instance.GetComponent<Rigidbody2D>().AddForce
            
            yield return new WaitForSeconds(0.2f);
        }

    }
}
