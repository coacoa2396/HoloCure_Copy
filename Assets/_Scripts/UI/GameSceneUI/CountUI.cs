using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CountUI : InGameUI
{
    [SerializeField] TMP_Text Coin;
    [SerializeField] TMP_Text Kill;
    
    [SerializeField] PlayerController player;
    [SerializeField] GameScene gameScene;

    protected override void Awake()
    {
        base.Awake();

        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        gameScene = GameObject.FindGameObjectWithTag("GameScene").GetComponent<GameScene>();
        
    }

    private void LateUpdate()
    {
        Coin.text = $"{player.curCoin}";
        Kill.text = $"{gameScene.killCount}";
    }
}
