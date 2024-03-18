using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverUI : PopUpUI
{
    [SerializeField] Animator animator;

    protected override void Awake()
    {
        base.Awake();
    }

    private void OnEnable()
    {
        Time.timeScale = 0f;
        animator.SetTrigger("GameOver");
    }

    public void GoTitle()
    {
        Manager.Scene.LoadScene("TitleScene");
    }

    public void ReStart()
    {
        Manager.Scene.LoadScene("GameScene");

        // 캐릭터 선택창 구현시 캐릭터 선택창으로 이동
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
