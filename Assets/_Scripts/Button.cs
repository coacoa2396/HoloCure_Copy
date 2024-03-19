using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Button : MonoBehaviour, IPointerEnterHandler, IPointerClickHandler
{
    public void OnPointerClick(PointerEventData eventData)
    {
        Manager.Sound.PlaySFX("ButtonClick");
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        Manager.Sound.PlaySFX("ButtonMove");
    }

    
}
