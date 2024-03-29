using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EXP_Bar : InGameUI
{
    [SerializeField] Slider slider;
    [SerializeField] PlayerController player;
    [SerializeField] TMP_Text text;

    protected override void Awake()
    {
        base.Awake();
        slider = GetComponent<Slider>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }

    private void LateUpdate()
    {
        float expPer = (float)player.curEXP / player.needEXP;                
        slider.value = expPer;
        text.text = $"LV : {player.level}";
    }
}
