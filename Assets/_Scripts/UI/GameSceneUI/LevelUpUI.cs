using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class LevelUpUI : PopUpUI
{
    [SerializeField] Image image_select1;
    [SerializeField] Image image_select2;
    [SerializeField] Image image_select3;

    [SerializeField] TMP_Text name_select1;
    [SerializeField] TMP_Text name_select2;
    [SerializeField] TMP_Text name_select3;

    [SerializeField] string des_select1;
    [SerializeField] string des_select2;
    [SerializeField] string des_select3;

    [SerializeField] Image curSelect;
    [SerializeField] Image curSprite;
    [SerializeField] TMP_Text curName;
    [SerializeField] TMP_Text curDesc;

   

    int sel1;
    int sel2;
    int sel3;
    int cur;


    [SerializeField] PlayerController player;
    [SerializeField] GameScene scene;
    [SerializeField] Equipment equipUI;
    [SerializeField] Sprite[] weaponSprites;


    List<Dictionary<string, object>> csv;

    protected override void Awake()
    {
        base.Awake();

        csv = CSVReader.Read("Data/CSV/ItemTable");
        sel1 = -1;
        sel2 = -1;
        sel3 = -1;

        scene = GameObject.FindGameObjectWithTag("GameScene").GetComponent<GameScene>();
        equipUI = GameObject.FindGameObjectWithTag("Equipment").GetComponent<Equipment>();
    }

    private void OnEnable()
    {
        RandomPick();
        SlotSet();
    }

    void RandomPick()
    {
        do
        {
            int[] rans = new int[3];

            int randomNumber = Random.Range(0, 6);      // 랜덤뽑기

            if (randomNumber == sel1 || randomNumber == sel2 || randomNumber == sel3)        // 중복체크
                continue;

            if (sel1 == -1)
            {
                rans[0] = randomNumber;
                sel1 = rans[0];
            }
            else if (sel2 == -1)
            {
                rans[1] = randomNumber;
                sel2 = rans[1];
            }
            else
            {
                rans[2] = randomNumber;
                sel3 = rans[2];
            }
        } while (sel3 == -1);
    }

    void SlotSet()
    {
        // 1번 슬롯
        // 해당 무기 소유 확인
        if (CheckActive(sel1))          // 가지고 있다면
        {
            // 무기 레벨업 스크립트
            name_select1.text = (string)csv[sel1]["name"];
            des_select1 = $"LevelUp of {(string)csv[sel1]["name"]}!!";
            image_select1.sprite = weaponSprites[sel1];
        }
        else                                    // 안가지고 있다면
        {
            // 무기 획득 스크립트
            name_select1.text = (string)csv[sel1]["name"];
            des_select1 = (string)csv[sel1]["Get"];
            image_select1.sprite = weaponSprites[sel1];
        }

        // 2번 슬롯
        // 해당 무기 소유 확인
        if (CheckActive(sel2))          // 가지고 있다면
        {
            // 무기 레벨업 스크립트
            name_select2.text = (string)csv[sel2]["name"];
            des_select2 = $"LevelUp of {(string)csv[sel2]["name"]}!!";
            image_select2.sprite = weaponSprites[sel2];
        }
        else                                    // 안가지고 있다면
        {
            // 무기 획득 스크립트
            name_select2.text = (string)csv[sel2]["name"];
            des_select2 = (string)csv[sel2]["Get"];
            image_select2.sprite = weaponSprites[sel2];
        }

        // 3번 슬롯
        // 해당 무기 소유 확인
        if (CheckActive(sel3))          // 가지고 있다면
        {
            // 무기 레벨업 스크립트
            name_select3.text = (string)csv[sel3]["name"];
            des_select3 = $"LevelUp of {(string)csv[sel3]["name"]}!!";
            image_select3.sprite = weaponSprites[sel3];
        }
        else                                    // 안가지고 있다면
        {
            // 무기 획득 스크립트
            name_select3.text = (string)csv[sel3]["name"];
            des_select3 = (string)csv[sel3]["Get"];
            image_select3.sprite = weaponSprites[sel3];
        }
    }

    bool CheckActive(int number)
    {
        if (scene.activeCheck[number].activeSelf == true)
        {
            return true;
        }
        else
        {
            return false;
        }
    }


    // slot3개 클릭 이벤트
    public void SetOnCurSelect()
    {
        curSelect.gameObject.SetActive(true);
    }

    public void ClickSlot1()
    {
        curName.text = name_select1.text;
        curDesc.text = des_select1;
        curSprite.sprite = image_select1.sprite;
        cur = sel1;
    }

    public void ClickSlot2()
    {
        curName.text = name_select2.text;
        curDesc.text = des_select2;
        curSprite.sprite = image_select2.sprite;
        cur = sel2;
    }

    public void ClickSlot3()
    {
        curName.text = name_select3.text;
        curDesc.text = des_select3;
        curSprite.sprite = image_select3.sprite;
        cur = sel3;
    }

    // 확정버튼
    public void OKButton()
    {
        LevelUp(cur);        
        LevelUpUIExit();
    }

    public void LevelUp(int number)
    {
        if (CheckActive(number))    // 가지고 있다면
        {
            // 레벨업
            scene.activeCheck[number].GetComponent<Weapon>().LevelUp();
        }
        else
        {
            // 해당 무기의 게임오브젝트를 셋 액티브
            scene.activeCheck[number].SetActive(true);
            equipUI.SetWeapon(curSprite.sprite);
        }
    }

    public void LevelUpUIExit()
    {
        Manager.UI.ClosePopUpUI();
    }
}
