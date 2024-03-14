using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fanbeam : Bullet
{
    [SerializeField] Animator animator;
    [SerializeField] Collider2D coll;

    protected override void Awake()
    {
        animator = GetComponent<Animator>();
        coll = GetComponent<Collider2D>();
    }

    protected override void Update() { }

    private void OnEnable()
    {
        animator.Play("FanBeam");
    }

    public void OnCollider()
    {
        coll.enabled = true;
    }

    public void OffCollider()
    {
        coll.enabled = false;
    }

    public void Setoff()
    {
        gameObject.SetActive(false);
    }
}
