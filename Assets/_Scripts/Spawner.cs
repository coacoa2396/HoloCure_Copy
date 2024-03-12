using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] Monster[] monsterPrefab;
    [SerializeField] Transform[] spawnPoint;
    [SerializeField] GameScene gameScene;

    float timer;
    public int level;
    float elapsedTime;

    private List<Dictionary<string, object>> csv;

    private void Awake()
    {
        gameScene = GameObject.FindGameObjectWithTag("GameScene").GetComponent<GameScene>();
        csv = CSVReader.Read("Data/CSV/MonsterLevelDesign");
    }



    private void Update()
    {
        timer += Time.deltaTime;
        level = (int)(gameScene.gameTime / 10f);
        elapsedTime = (float)csv[gameScene.level]["spawnTime"];

        SpawnCheck(level, elapsedTime, timer);
    }

    void Spawn(int level)
    {
        if (level < 20)
        {
            Manager.Pool.GetPool(monsterPrefab[level], spawnPoint[Random.Range(0, spawnPoint.Length)].transform.position, Quaternion.identity);
        }
        else
        {
            Manager.Pool.GetPool(monsterPrefab[Random.Range(0, monsterPrefab.Length)], spawnPoint[Random.Range(0, spawnPoint.Length)].transform.position, Quaternion.identity);
        }
    }

    void SpawnCheck(int level, float elapsedTime, float timer)
    {
        switch (level)
        {
            case 0: // 0 ~ 59
                if (timer > elapsedTime)
                {
                    timer = 0f;
                    Spawn(level);
                }
                break;
            case 1: // 60 ~ 119              
                if (timer > elapsedTime)
                {
                    timer = 0f;
                    Spawn(level);
                }
                break;
            case 2: // 120 ~ 179
                if (timer > elapsedTime)
                {
                    timer = 0f;
                    Spawn(level);
                }
                break;
            case 3: // 180 ~ 239
                if (timer > elapsedTime)
                {
                    timer = 0f;
                    Spawn(level);
                }
                break;
            case 4: // 240 ~ 299
                if (timer > elapsedTime)
                {
                    timer = 0f;
                    Spawn(level);
                }
                break;
            case 5: // 300 ~ 359
                if (timer > elapsedTime)
                {
                    timer = 0f;
                    Spawn(level);
                }
                break;
            case 6: // 360 ~ 419
                if (timer > elapsedTime)
                {
                    timer = 0f;
                    Spawn(level);
                }
                break;
            case 7: // 420 ~ 479
                if (timer > elapsedTime)
                {
                    timer = 0f;
                    Spawn(level);
                }
                break;
            case 8: // 480 ~ 539
                if (timer > elapsedTime)
                {
                    timer = 0f;
                    Spawn(level);
                }
                break;
            case 9: // 540 ~ 599
                if (timer > elapsedTime)
                {
                    timer = 0f;
                    Spawn(level);
                }
                break;
            case 10: // 600 ~ 659
                if (timer > elapsedTime)
                {
                    timer = 0f;
                    Spawn(level);
                }
                break;
            case 11: // 660 ~ 719
                if (timer > elapsedTime)
                {
                    timer = 0f;
                    Spawn(level);
                }
                break;
            case 12: // 720 ~ 779
                if (timer > elapsedTime)
                {
                    timer = 0f;
                    Spawn(level);
                }
                break;
            case 13: // 780 ~ 839
                if (timer > elapsedTime)
                {
                    timer = 0f;
                    Spawn(level);
                }
                break;
            case 14: // 840 ~ 899
                if (timer > elapsedTime)
                {
                    timer = 0f;
                    Spawn(level);
                }
                break;
            case 15: // 900 ~ 959
                if (timer > elapsedTime)
                {
                    timer = 0f;
                    Spawn(level);
                }
                break;
            case 16: // 960 ~ 1019
                if (timer > elapsedTime)
                {
                    timer = 0f;
                    Spawn(level);
                }
                break;
            case 17: // 1020 ~ 1079
                if (timer > elapsedTime)
                {
                    timer = 0f;
                    Spawn(level);
                }
                break;
            case 18: // 1080 ~ 1139
                if (timer > elapsedTime)
                {
                    timer = 0f;
                    Spawn(level);
                }
                break;
            case 19: // 1140 ~ 1199
                if (timer > elapsedTime)
                {
                    timer = 0f;
                    Spawn(level);
                }
                break;
            case 20: // 1200 ~
                if (timer > elapsedTime)
                {
                    timer = 0f;
                    Spawn(level);
                }
                break;
            default:
                break;
        }
    }

}
