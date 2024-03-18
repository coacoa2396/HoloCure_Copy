using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class SpiderCooking : MonoBehaviour, IActiveCheck
{
    [SerializeField] public int atk;
    [SerializeField] public float interval;

    float timer;

    private void Update()
    {
        timer += Time.deltaTime;

        if (timer > interval)
        {
            timer = 0;
            TickAttack();
        }
    }

    Collider2D[] colliders = new Collider2D[30];
    void TickAttack()
    {
        int size = Physics2D.OverlapCircleNonAlloc(transform.position, 5f, colliders);
        for (int i = 0; i < size; i++)
        {
            IDamagable damagable = colliders[i].GetComponent<IDamagable>();
            damagable?.TakeDamage(atk);
        }
    }

    private void OnDrawGizmosSelected()
    {
        

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, 5f);
    }
}
