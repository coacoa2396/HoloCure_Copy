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

        if (timer > elapsedTime)
        {
            timer = 0f;
            Debug.Log($"생성 전 레벨 : {level}");
            Spawn(level);
        }
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

    

}
