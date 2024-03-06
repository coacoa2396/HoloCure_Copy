using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] Monster[] monsterPrefab;
    [SerializeField] Transform[] spawnPoint;

    float timer;

    private void Awake()
    {
        Manager.Pool.CreatePool(monsterPrefab[0], 100, 200);
    }

    private void Start()
    {
    }

    private void Update()
    {
        timer += Time.deltaTime;

        if (timer > 0.2f)
        {
            timer = 0f;
            Spawn();
        }
    }

    void Spawn()
    {
        Manager.Pool.GetPool(monsterPrefab[0], spawnPoint[Random.Range(0, spawnPoint.Length)].transform.position, Quaternion.identity);
        
    }
}
