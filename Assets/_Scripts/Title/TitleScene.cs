using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleScene : BaseScene
{
    public void NewGame()
    {
        Manager.Scene.LoadScene("GameScene");
    }

    public override IEnumerator LoadingRoutine()
    {
        yield return null;
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
