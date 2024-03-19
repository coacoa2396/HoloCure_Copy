using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TitleButton : MonoBehaviour, IPointerEnterHandler, IPointerClickHandler
{
    public void OnPointerClick(PointerEventData eventData)
    {
        Manager.Sound.PlaySFX("TitleButtonClick");
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        Manager.Sound.PlaySFX("TitleButtonMove");
    }
}
