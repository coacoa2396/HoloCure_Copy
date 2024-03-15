using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallAme : Boss
{
    Collider2D coll;
    Collider2D coll2;
    Collider2D shadowColl;

    float skillCoolTime;


    bool skillOn;

    float timer;

    protected override void Awake()
    {
        base.Awake();
        Collider2D[] colliders = GetComponents<Collider2D>();
        coll = colliders[0];
        coll2 = colliders[1];
        shadowColl = GetComponentInChildren<Collider2D>();

        MaxHP = 1;
        ATK = 25;
        Speed = 2;
        HP = MaxHP;
        skillCoolTime = 15f;
        timer = 10f;
        skillOn = false;
    }

    private void Update()
    {
        timer += Time.deltaTime;

        if (timer > skillCoolTime)
        {
            timer = 0f;
            SetTrrigerOn();
        }

        if (Mathf.Abs(Vector2.Distance(transform.position, target.position)) < 0.1f)
        {
            skillOn = false;
        }
    }


    protected override void FixedUpdate()
    {
        if (skillOn)
        {
            SuperTracing();
        }
        else
        {
            Tracing(target);
        }

    }

    protected override void LateUpdate()
    {
        base.LateUpdate();
    }

    void SuperTracing()
    {
        if (isLive == false)
            return;
        float distance = Vector2.Distance(transform.position, target.position);
        Vector2 targetDir = (target.transform.position - transform.position).normalized;
        Vector2 nextDir = targetDir * 50 * Speed * Time.fixedDeltaTime;

        if (distance < nextDir.magnitude)
        {
            rigid.MovePosition(target.transform.position);
        }
        else
        {
            rigid.MovePosition(rigid.position + nextDir);
        }
    }



    protected override void Tracing(Rigidbody2D target)
    {
        if (isLive == false)
            return;

        if (!(Vector2.Distance(transform.position, target.position) < 0.1f))
        {
            Vector2 targetDir = (target.transform.position - transform.position).normalized;
            Vector2 nextDir = targetDir * Speed * Time.fixedDeltaTime;


            rigid.MovePosition(rigid.position + nextDir);
        }

    }

    void SkillOn()
    {
        skillOn = true;
    }

    void SkillOff()
    {
        skillOn = false;
    }

    void ColliderOn()
    {
        coll.enabled = true;
        coll.enabled = true;
    }

    void ColliderOff()
    {
        coll.enabled = false;
        coll2.enabled = false;
    }

    void ShadowColliderOn()
    {
        shadowColl.enabled = true;
    }

    void ShadowColliderOff()
    {
        shadowColl.enabled = false;
    }

    void SetTrrigerOn()
    {
        animator.SetTrigger("GroundPound");
    }
}
