using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;
using UnityEngine.UI;

public class Equipment : InGameUI
{
    [SerializeField] public PlayerController player;
    [SerializeField] public WSlot[] weapons;
    [SerializeField] public ESlot[] equipments;


    protected override void Awake()
    {
        base.Awake();
        weapons = GetComponentsInChildren<WSlot>();
        equipments = GetComponentsInChildren<ESlot>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }

    private void Start()
    {
        weapons[0].SetCurState(WSlot.State.Full);
        Image curSpr = weapons[0].GetComponent<Image>();        // 비어있는 상태라면 스프라이트를 바꾸고 스케일을 키우고 컬러알파값 255
        curSpr.sprite = player.personalWeaponSprite;
        curSpr.color = new Color(1, 1, 1, 1);
        curSpr.transform.localScale = new Vector3(1, 1, 1);
    }

    public void SetWeapon(Sprite sprite)
    {
        // 첫번째 슬롯부터 하나씩 확인하기
        for (int i = 0; i < weapons.Length; i++)
        {
            if (weapons[i].GetCurState() == WSlot.State.Full)       // 비어있지 않다면 다음슬롯 확인하기
                continue;

            weapons[i].SetCurState(WSlot.State.Full);
            Image curSpr = weapons[i].GetComponent<Image>();        // 비어있는 상태라면 스프라이트를 바꾸고 스케일을 키우고 컬러알파값 255
            curSpr.sprite = sprite;
            curSpr.color = new Color(1, 1, 1, 1);
            curSpr.transform.localScale = new Vector3(1, 1, 1);
            return;
        }
    }
}

