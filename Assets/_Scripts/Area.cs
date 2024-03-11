using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Area : MonoBehaviour
{
    private void Update()
    {
        Vector2 playerPos = GameObject.FindGameObjectWithTag("Player").transform.position;

        transform.position = playerPos;
    }
}
