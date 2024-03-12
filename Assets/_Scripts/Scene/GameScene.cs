using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScene : BaseScene
{
    [SerializeField] Monster[] monsterPrefab;
    [SerializeField] Bullet[] Weapons;
    public float gameTime;
    public float maxGameTime = 6 * 10f;
    public int level;
    private void Awake()
    {
        for (int i = 0; i < monsterPrefab.Length; i++)
        {
            Manager.Pool.CreatePool(monsterPrefab[i], 128, 1024);
        }


        Manager.Pool.CreatePool(Weapons[0], 128, 512);
    }

    private void Update()
    {
        gameTime += Time.deltaTime;

        if (gameTime > maxGameTime)
        {
            gameTime = maxGameTime;
        }
    }

    private void LateUpdate()
    {
        level = (int)(gameTime / 10f);
    }

    public override IEnumerator LoadingRoutine()
    {
        yield return null;
    }


}
