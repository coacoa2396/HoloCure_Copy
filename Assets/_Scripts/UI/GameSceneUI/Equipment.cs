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
        Image curSpr = weapons[0].GetComponent<Image>();        // ����ִ� ���¶�� ��������Ʈ�� �ٲٰ� �������� Ű��� �÷����İ� 255
        curSpr.sprite = player.personalWeaponSprite;
        curSpr.color = new Color(1, 1, 1, 1);
        curSpr.transform.localScale = new Vector3(1, 1, 1);
    }

    public void SetWeapon(Sprite sprite)
    {
        // ù��° ���Ժ��� �ϳ��� Ȯ���ϱ�
        for (int i = 0; i < weapons.Length; i++)
        {
            if (weapons[i].GetCurState() == WSlot.State.Full)       // ������� �ʴٸ� �������� Ȯ���ϱ�
                continue;

            weapons[i].SetCurState(WSlot.State.Full);
            Image curSpr = weapons[i].GetComponent<Image>();        // ����ִ� ���¶�� ��������Ʈ�� �ٲٰ� �������� Ű��� �÷����İ� 255
            curSpr.sprite = sprite;
            curSpr.color = new Color(1, 1, 1, 1);
            curSpr.transform.localScale = new Vector3(1, 1, 1);
            return;
        }
    }
}

