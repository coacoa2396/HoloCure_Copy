using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimeCheckUI : InGameUI
{
    [SerializeField] TMP_Text text;

    int min;
    float sec;

    private void Update()
    {
        sec += Time.deltaTime;
        if (sec > 60)
        {
            min++;
            sec = 0;
        }

        text.text = $"{min}:{(int)sec}";
    }
}
