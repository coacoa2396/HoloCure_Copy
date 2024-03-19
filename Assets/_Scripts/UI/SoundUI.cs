using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundUI : PopUpUI
{
    public Slider master_slider;
    public Slider bgm_slider;
    public Slider sfx_slider;

    public void MasterCon()
    {
        float sound = master_slider.value;

        if (sound == -40f) Manager.Sound.mixer.SetFloat("Master", -80);
        else Manager.Sound.mixer.SetFloat("Master", sound);
    }

    public void BGMCon()
    {
        float sound = bgm_slider.value;

        if (sound == -40f) Manager.Sound.mixer.SetFloat("BGM", -80);
        else Manager.Sound.mixer.SetFloat("BGM", sound);
    }

    public void SFXCon()
    {
        float sound = sfx_slider.value;

        if (sound == -40f) Manager.Sound.mixer.SetFloat("SFX", -80);
        else Manager.Sound.mixer.SetFloat("SFX", sound);
    }

    public void CloseSoundUI()
    {
        Manager.UI.ClearPopUpUI();
    }
}
