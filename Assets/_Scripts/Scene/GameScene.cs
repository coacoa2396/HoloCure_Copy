using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScene : BaseScene
{
    [SerializeField] Monster[] monsterPrefab;
    [SerializeField] Weapon[] Weapons;
    [SerializeField] public Item[] items;

    [SerializeField] GameOverUI gameOverUI;

    public float gameTime;
    public float maxGameTime = 4 * 10f;
    public int level;
    public int killCount;

    private void Awake()
    {
        for (int i = 0; i < monsterPrefab.Length; i++)
        {
            Manager.Pool.CreatePool(monsterPrefab[i], 128, 1024);
        }

        for (int i = 0; i < Weapons.Length; i++)
        {
            Manager.Pool.CreatePool(Weapons[i], 128, 512);
        }

        for (int i = 0;i < items.Length; i++)
        {
            if (i == 2)
            {
                Manager.Pool.CreatePool(items[i], 16, 32);
                continue;
            }
            Manager.Pool.CreatePool(items[i], 128, 1024);
        }
    }

    private void Update()
    {
        gameTime += Time.deltaTime;        
    }

    private void LateUpdate()
    {
        level = (int)(gameTime / 2f);        
    }

    public override IEnumerator LoadingRoutine()
    {
        yield return null;
    }

    public void SetOnGameOverUI()
    {
        gameOverUI.gameObject.SetActive(true);
    }
}
