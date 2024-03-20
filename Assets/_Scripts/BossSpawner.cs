using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSpawner : Spawner
{
    [SerializeField] Monster[] semiBosses;

    protected override void Awake()
    {
        gameScene = GameObject.FindGameObjectWithTag("GameScene").GetComponent<GameScene>();
    }

    protected override void Update()
    {
        if ((int)gameScene.gameTime == 600)
        {
            Spawn(monsterPrefab[0]);
        }
        else if ((int)gameScene.gameTime > 1200f)
        {
            Spawn(monsterPrefab[1]);
        }

        if((int)gameScene.gameTime == 200f)
        {
            Spawn(semiBosses[0]);
        }
        else if ((int)gameScene.gameTime == 400f)
        {
            Spawn(semiBosses[1]);
        }
        else if ((int)gameScene.gameTime == 800f)
        {
            Spawn(semiBosses[2]);
        }
        else if ((int)gameScene.gameTime == 1000f)
        {
            Spawn(semiBosses[3]);
        }

    }

    void Spawn(Monster monster)
    {
        Instantiate(monster, spawnPoint[Random.Range(0, spawnPoint.Length)].transform.position, Quaternion.identity);
    }
}
