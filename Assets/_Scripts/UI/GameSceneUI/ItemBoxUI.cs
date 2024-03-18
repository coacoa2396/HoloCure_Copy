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
        icon.SetActive(true);                   // 박스 아이콘 켜고
        scriptBG.gameObject.SetActive(true);    // 스크립트창 켜고
        IconInit();                             // 박스 아이콘 할당하고
        itemName.text = $"{box.getName}";           // 스크립트 할당하고
        itemType.text = "Weapon";
        itemDescription.text = $"{box.getScript}";
        scriptIcon.sprite = icon.GetComponent<Image>().sprite;  // 스크립트 창의 아이콘도 할당해준다

        OpenButton.gameObject.SetActive(false);     // 오픈버튼은 꺼주고

        GetButton.gameObject.SetActive(true);       // 겟 버튼과
        ExitButton.gameObject.SetActive(true);      // 엑시트 버튼은 켜준다
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
