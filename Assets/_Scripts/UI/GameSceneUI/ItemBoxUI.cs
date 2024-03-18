using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemBoxUI : PopUpUI
{
    [SerializeField] Animator animator;
    [SerializeField] GameObject icon;
    [SerializeField] ItemBox box;

    [SerializeField] Button OpenButton;
    [SerializeField] Button GetButton;
    [SerializeField] Button ExitButton;
    [SerializeField] Image scriptBG;
    [SerializeField] TMP_Text itemName;
    [SerializeField] TMP_Text itemType;
    [SerializeField] TMP_Text itemDescription;
    [SerializeField] Image scriptIcon;

    ItemBox[] itemBoxes;

    protected override void Awake()
    {
        base.Awake();
        animator = GetComponent<Animator>();
    }
    
    private void OnEnable()
    {
        Debug.Log("OnEnable");
        animator.SetTrigger("GetBox");

        itemBoxes = FindObjectsOfType<ItemBox>();
        
    }

    public void Open()
    {
        animator.SetTrigger("OpenBox");
    }

    public void AfterOpened()
    {
        icon.SetActive(true);                   // �ڽ� ������ �Ѱ�
        scriptBG.gameObject.SetActive(true);    // ��ũ��Ʈâ �Ѱ�
        IconInit();                             // �ڽ� ������ �Ҵ��ϰ�
        itemName.text = $"{box.getName}";           // ��ũ��Ʈ �Ҵ��ϰ�
        itemType.text = "Weapon";
        itemDescription.text = $"{box.getScript}";
        scriptIcon.sprite = icon.GetComponent<Image>().sprite;  // ��ũ��Ʈ â�� �����ܵ� �Ҵ����ش�

        OpenButton.gameObject.SetActive(false);     // ���¹�ư�� ���ְ�

        GetButton.gameObject.SetActive(true);       // �� ��ư��
        ExitButton.gameObject.SetActive(true);      // ����Ʈ ��ư�� ���ش�
    }

    public void IconInit()
    {
        for (int i = 0; i < itemBoxes.Length; i++)
        {
            if (itemBoxes[i].getSprite == null)
                continue;

            icon.GetComponent<Image>().sprite = itemBoxes[i].getSprite;
            break;
        }
    }
    
    public void SetBox(ItemBox box)
    {
        this.box = box;
    }

    public void OnClickGet()
    {
        box.LevelUp(box.randomNumber);
        box.DestroyBox();
        BoxUIExit();
    }

    public void OnClickExit()
    {
        box.DestroyBox();
        BoxUIExit();
    }

    public void BoxUIExit()
    {
        Manager.UI.ClosePopUpUI();
    }
}
