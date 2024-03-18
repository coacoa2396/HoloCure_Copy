using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : PooledObject
{
    [SerializeField] protected Collider2D coll;
    [SerializeField] protected PlayerController player;

    protected virtual void OnEnable()
    {
        coll = GetComponent<Collider2D>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }

    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        gameObject.SetActive(false);
    }

}
