using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverUI : InGameUI
{
    [SerializeField] Animator animator;

    private void OnEnable()
    {
        Time.timeScale = 0f;
        animator.SetTrigger("GameOver");
        Manager.Sound.StopBGM();
        Manager.Sound.PlaySFX("GameOver");
    }

    public void GoTitle()
    {
        Manager.Scene.LoadScene("TitleScene");
    }

    public void ReStart()
    {
        Manager.Scene.LoadScene("GameScene");

        // ĳ���� ����â ������ ĳ���� ����â���� �̵�
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
