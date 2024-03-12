using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleScene : BaseScene
{
    public void GoCharSelect()
    {
        Manager.Scene.LoadScene("CharSelectScene");
    }

    public override IEnumerator LoadingRoutine()
    {
        yield return null;
    }
}
