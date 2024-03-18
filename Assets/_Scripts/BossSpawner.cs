using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSpawner : Spawner
{
    protected override void Awake()
    {
        gameScene = GameObject.FindGameObjectWithTag("GameScene").GetComponent<GameScene>();
    }

    protected override void Update()
    {
        if (gameScene.gameTime > 600f)
        {
            Spawn(monsterPrefab[0]);
        }
        else if (gameScene.gameTime > 1200f)
        {
            Spawn(monsterPrefab[1]);
        }

    }

    void Spawn(Monster monster)
    {
        Instantiate(monster, spawnPoint[Random.Range(0, spawnPoint.Length)].transform.position, Quaternion.identity);
    }
}
