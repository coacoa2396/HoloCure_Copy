using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSpawner : Spawner
{
    [SerializeField] Monster[] semiBosses;

    bool on1;
    bool on2;
    bool on3;
    bool on4;
    bool on5;
    bool on6;

    protected override void Awake()
    {
        gameScene = GameObject.FindGameObjectWithTag("GameScene").GetComponent<GameScene>();
        on1 = false;
        on2 = false;
        on3 = false;
        on4 = false;
        on5 = false;
        on6 = false;
    }

    protected override void Update()
    {
        if ((int)gameScene.gameTime == 60)
        {
            if (!on1)
            {
                Spawn(monsterPrefab[0]);
                on1 = true;
            }
        }
        else if ((int)gameScene.gameTime > 120)
        {
            if (!on2)
            {
                Spawn(monsterPrefab[1]);

                on2 = true;
            }
        }

        if ((int)gameScene.gameTime == 200f)
        {
            if (!on3)
                Spawn(semiBosses[0]); on3 = true;
        }
        else if ((int)gameScene.gameTime == 400f)
        {
            if (!on4)
                Spawn(semiBosses[1]); on4 = true;
        }
        else if ((int)gameScene.gameTime == 800f)
        {
            if (!on5)
                Spawn(semiBosses[2]); on5 = true;
        }
        else if ((int)gameScene.gameTime == 1000f)
        {
            if (!on6)
                Spawn(semiBosses[3]); on6 = true;
        }
    }

    void Spawn(Monster monster)
    {
        Instantiate(monster, spawnPoint[Random.Range(0, spawnPoint.Length)].transform.position, Quaternion.identity);
    }
}
