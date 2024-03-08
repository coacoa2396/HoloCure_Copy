using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScene : BaseScene
{
    [SerializeField] Monster[] monsterPrefab;
    public float gameTime;
    public float maxGameTime = 6 * 10f;

    private void Awake()
    {
        Manager.Pool.CreatePool(monsterPrefab[0], 128, 512);
        Manager.Pool.CreatePool(monsterPrefab[1], 128, 512);
        Manager.Pool.CreatePool(monsterPrefab[2], 128, 512);
        Manager.Pool.CreatePool(monsterPrefab[3], 128, 512);
        Manager.Pool.CreatePool(monsterPrefab[4], 128, 512);
        Manager.Pool.CreatePool(monsterPrefab[5], 128, 512);
        Manager.Pool.CreatePool(monsterPrefab[6], 128, 512);
        Manager.Pool.CreatePool(monsterPrefab[7], 128, 512);
    }

    private void Update()
    {
        gameTime += Time.deltaTime;

        if (gameTime > maxGameTime)
        {
            gameTime = maxGameTime;
        }


    }

    public override IEnumerator LoadingRoutine()
    {
        yield return null;
    }

    
}
