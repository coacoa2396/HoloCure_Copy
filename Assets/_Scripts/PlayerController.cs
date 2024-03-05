using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    Vector2 inputVec;
    [SerializeField] float speed;
    [SerializeField] Rigidbody2D rigid;
    [SerializeField] SpriteRenderer spriter;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        spriter = GetComponentInChildren<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void LateUpdate()
    {
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
