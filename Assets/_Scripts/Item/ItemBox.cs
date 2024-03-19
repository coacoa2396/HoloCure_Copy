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
                
        // ���� �������� ������
        randomNumber = Random.Range(0, 6);

        // �ش� ���� ���� Ȯ��
        if (CheckActive(randomNumber))          // ������ �ִٸ�
        {
            // ���� ������ ��ũ��Ʈ
            getName = (string)csv[randomNumber]["name"];
            getScript = $"LevelUp of {(string)csv[randomNumber]["name"]}!!";
            getSprite = weaponSprites[randomNumber];
        }
        else                                    // �Ȱ����� �ִٸ�
        {
            // ���� ȹ�� ��ũ��Ʈ
            getName = (string)csv[randomNumber]["name"];
            getScript = (string)csv[randomNumber]["Get"];
            getSprite = weaponSprites[randomNumber];            
        }

        // �����۹ڽ� ui �ҷ�����
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
        if (CheckActive(number))    // ������ �ִٸ�
        {
            // ������
            activeCheck[number].GetComponent<Weapon>().LevelUp();
        }
        else
        {
            // �ش� ������ ���ӿ�����Ʈ�� �� ��Ƽ��
            activeCheck[number].SetActive(true);
            
        }
    }

    public void DestroyBox()
    {
        // ���ӿ�����Ʈ �ı�
        gameObject.SetActive(false);
    }


}
