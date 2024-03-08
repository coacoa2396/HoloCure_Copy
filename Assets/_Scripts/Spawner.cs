using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] Monster[] monsterPrefab;
    [SerializeField] Transform[] spawnPoint;
    [SerializeField] GameScene gameScene;

    float timer;
    int level;


    private void Awake()
    {
        gameScene = GameObject.FindGameObjectWithTag("GameScene").GetComponent<GameScene>();
    }



    private void Update()
    {
        timer += Time.deltaTime;
        level = (int)(gameScene.gameTime / 10f);

        switch (level)
        {
            case 0: // 0 ~ 59
                if (timer > 0.7f)
                {
                    timer = 0f;
                    Spawn(level);
                }
                break;
            case 1: // 60 ~ 119              
                if (timer > 0.7f)
                {
                    timer = 0f;
                    Spawn(level);
                }
                break;
            case 2: // 120 ~ 179
                if (timer > 0.7f)
                {
                    timer = 0f;
                    Spawn(level);
                }
                break;
            case 3: // 180 ~ 239
                if (timer > 0.5f)
                {
                    timer = 0f;
                    Spawn(level);
                }
                break;
            case 4: // 240 ~ 299
                if (timer > 0.5f)
                {
                    timer = 0f;
                    Spawn(level);
                }
                break;
            case 5: // 300 ~ 359
                if (timer > 0.5f)
                {
                    timer = 0f;
                    Spawn(level);
                }
                break;
            default:
                break;
        }
    }

    void Spawn(int level)
    {
        Manager.Pool.GetPool(monsterPrefab[level], spawnPoint[Random.Range(0, spawnPoint.Length)].transform.position, Quaternion.identity);
    }

}
