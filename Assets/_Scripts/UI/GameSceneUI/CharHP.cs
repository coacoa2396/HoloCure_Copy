using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CharHP : InGameUI
{
    [SerializeField] Slider hpBar;
    [SerializeField] TMP_Text text;

    [SerializeField] PlayerController player;

    protected override void Awake()
    {
        base.Awake();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }

    private void LateUpdate()
    {
        float hpPer = (float)player.HP / player.MaxHP;
        hpBar.value = hpPer;

        text.text = $"{player.HP} / {player.MaxHP}";
    }
}
