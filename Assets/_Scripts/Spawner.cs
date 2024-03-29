using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] protected Monster[] monsterPrefab;
    [SerializeField] protected Transform[] spawnPoint;
    [SerializeField] protected GameScene gameScene;

    protected float timer;
    public int level;
    protected float elapsedTime;

    private List<Dictionary<string, object>> csv;

    protected virtual void Awake()
    {
        gameScene = GameObject.FindGameObjectWithTag("GameScene").GetComponent<GameScene>();
        csv = CSVReader.Read("Data/CSV/MonsterLevelDesign");
    }



    protected virtual void Update()
    {
        timer += Time.deltaTime;
        level = (int)(gameScene.gameTime / 2f);

        if (level < 20)
        {
            elapsedTime = (float)csv[gameScene.level]["spawnTime"];
        }
        else
        {
            level = 20;
            elapsedTime = (float)csv[20]["spawnTime"];
        }

        if (timer > elapsedTime)
        {
            timer = 0f;            
            Spawn(level);
        }
    }

    protected void Spawn(int level)
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
