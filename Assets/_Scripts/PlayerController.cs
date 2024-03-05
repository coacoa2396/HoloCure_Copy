using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public Vector2 inputVec;
    [SerializeField] float speed;
    [SerializeField] Rigidbody2D rigid;
    [SerializeField] SpriteRenderer spriter;
    [SerializeField] Animator animator;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        spriter = GetComponentInChildren<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void LateUpdate()
    {
        animator.SetFloat("Speed", inputVec.magnitude);

        if (inputVec.x != 0)
        {
            spriter.flipX = inputVec.x < 0;
        }
    }

    void Move()
    {
        Vector2 nextVec = inputVec.normalized * speed * Time.fixedDeltaTime;
        
        rigid.MovePosition(rigid.position + nextVec);        
    }

    void OnMove(InputValue value)
    {
        Vector2 input = value.Get<Vector2>();
        inputVec.x = input.x;
        inputVec.y = input.y;
    }
}
