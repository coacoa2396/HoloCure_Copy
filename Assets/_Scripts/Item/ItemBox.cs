using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBox : Item
{
    [SerializeField] Sprite[] weaponSprites;
    [SerializeField] GameObject[] activeCheck;
    [SerializeField] ItemBoxUI ui;
    [SerializeField] public Equipment equipUI;

    List<Dictionary<string, object>> csv;

    public int randomNumber;
    public string getName;
    public string getScript;
    public Sprite getSprite;

    private void Awake()
    {
        coll = GetComponent<Collider2D>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        
        
        csv = CSVReader.Read("Data/CSV/ItemTable");

        activeCheck[0] = GameObject.FindGameObjectWithTag("AmePistol");
        activeCheck[1] = GameObject.FindGameObjectWithTag("PsychoAxe");
        activeCheck[2] = GameObject.FindGameObjectWithTag("BLBook");
        activeCheck[3] = GameObject.FindGameObjectWithTag("FanBeam");
        activeCheck[4] = GameObject.FindGameObjectWithTag("SpiderCooking");
        activeCheck[5] = GameObject.FindGameObjectWithTag("HoloBomb");                
    }

    protected override void OnEnable()
    {
        base.OnEnable();
        equipUI = FindAnyObjectByType<Equipment>();
    }

    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        if (!(collision.transform.tag == "Player"))
            return;
                
        // 무기 랜덤으로 돌리기
        randomNumber = Random.Range(0, 6);

        // 해당 무기 소유 확인
        if (CheckActive(randomNumber))          // 가지고 있다면
        {
            // 무기 레벨업 스크립트
            getName = (string)csv[randomNumber]["name"];
            getScript = $"LevelUp of {(string)csv[randomNumber]["name"]}!!";
            getSprite = weaponSprites[randomNumber];
        }
        else                                    // 안가지고 있다면
        {
            // 무기 획득 스크립트
            getName = (string)csv[randomNumber]["name"];
            getScript = (string)csv[randomNumber]["Get"];
            getSprite = weaponSprites[randomNumber];            
        }

        // 아이템박스 ui 불러오기
        ItemBoxUI initUI = Manager.UI.ShowPopUpUI(ui);
        initUI.SetBox(this);
    }

    bool CheckActive(int number)
    {
        if (activeCheck[number].activeSelf == true)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void LevelUp(int number)
    {
        if (CheckActive(number))    // 가지고 있다면
        {
            // 레벨업
            activeCheck[number].GetComponent<Weapon>().LevelUp();
        }
        else
        {
            // 해당 무기의 게임오브젝트를 셋 액티브
            activeCheck[number].SetActive(true);
            
        }
    }

    public void DestroyBox()
    {
        // 게임오브젝트 파괴
        gameObject.SetActive(false);
    }


}
