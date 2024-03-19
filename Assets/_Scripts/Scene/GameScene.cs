using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameScene : BaseScene
{
    [SerializeField] Monster[] monsterPrefab;
    [SerializeField] Weapon[] Weapons;
    [SerializeField] public Item[] items;
    [SerializeField] public GameObject[] activeCheck;

    [SerializeField] GameOverUI gameOverUI;
    [SerializeField] GameClearUI gameClearUI;

    private bool _isGameClear;

    public bool isGameClear
    {
        get { return _isGameClear; }
        set
        {
            _isGameClear = value;
            if (_isGameClear == true)
                OnCleared?.Invoke();
        }
    }

    public float gameTime;
    public float maxGameTime = 4 * 10f;
    public int level;
    public int killCount;

    [SerializeField] UnityEvent OnCleared;

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

        activeCheck[0] = GameObject.FindGameObjectWithTag("AmePistol");
        activeCheck[1] = GameObject.FindGameObjectWithTag("PsychoAxe");
        activeCheck[2] = GameObject.FindGameObjectWithTag("BLBook");
        activeCheck[3] = GameObject.FindGameObjectWithTag("FanBeam");
        activeCheck[4] = GameObject.FindGameObjectWithTag("SpiderCooking");
        activeCheck[5] = GameObject.FindGameObjectWithTag("HoloBomb");
    }

    private void Start()
    {
        isGameClear = false;
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

    public void SetOnGameClearUI()
    {
        gameClearUI.gameObject.SetActive(true);
    }

    public void ClearGame()
    {
        StartCoroutine(Clear());
    }

    IEnumerator Clear()
    {
        yield return new WaitForSecondsRealtime(1f);

        SetOnGameClearUI();
    }
}
