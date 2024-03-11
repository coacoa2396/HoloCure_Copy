using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TitleVtuberMove : MonoBehaviour
{
    private const float RANGE = 0.1f;

    Vector2 initPos;
    private float speed;
    private float elapsedTime;

    private Transform transform;
    private void Awake()
    {
        transform = gameObject.GetComponent<Transform>();
    }

    private void Start()
    {
        initPos = transform.position;
        speed = Random.Range(2f, 3f);
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        elapsedTime += Time.unscaledDeltaTime;
        transform.position = initPos + (RANGE * Mathf.Sin(elapsedTime * speed) * Vector2.up);
    }
}
