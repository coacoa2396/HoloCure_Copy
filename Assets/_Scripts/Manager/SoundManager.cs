using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Sound
{
    public string name;
    public AudioClip clip;
}

public class SoundManager : Singleton<SoundManager>
{


    [SerializeField] Sound[] sfx = null;
    [SerializeField] Sound[] bgm = null;

    [SerializeField] AudioSource bgmPlayer = null;
    [SerializeField] AudioSource[] sfxPlayer = null;


    public void PlayBGM(string p_bgmName)
    {
        for (int i = 0; i < bgm.Length; i++)
        {
            if (p_bgmName == bgm[i].name)
            {
                bgmPlayer.clip = bgm[i].clip;
                bgmPlayer.Play();
            }
        }
    }

    public void StopBGM()
    {
        bgmPlayer.Stop();
    }

    public void PlaySFX(string p_sfxName)
    {
        for (int i = 0; i < sfx.Length; i++)
        {
            if (p_sfxName == sfx[i].name)
            {
                for (int j = 0; j < sfxPlayer.Length; j++)
                {
                    // SFXPlayer���� ��� ������ ���� Audio Source�� �߰��ߴٸ� 
                    if (!sfxPlayer[j].isPlaying)
                    {
                        sfxPlayer[j].clip = sfx[i].clip;
                        sfxPlayer[j].Play();
                        return;
                    }
                }
                Debug.Log("��� ����� �÷��̾ ������Դϴ�.");
                return;
            }
        }
        Debug.Log(p_sfxName + " �̸��� ȿ������ �����ϴ�.");
        return;
    }    
}














//public class SoundManager : Singleton<SoundManager>
//{
//    [SerializeField] AudioSource bgmSource;
//    [SerializeField] AudioSource sfxSource;

//    public float BGMVolme { get { return bgmSource.volume; } set { bgmSource.volume = value; } }
//    public float SFXVolme { get { return sfxSource.volume; } set { sfxSource.volume = value; } }

//    public void PlayBGM(AudioClip clip)
//    {
//        if (bgmSource.isPlaying)
//        {
//            bgmSource.Stop();
//        }
//        bgmSource.clip = clip;
//        bgmSource.Play();
//    }

//    public void StopBGM()
//    {
//        if (bgmSource.isPlaying == false)
//            return;

//        bgmSource.Stop();
//    }

//    public void PlaySFX(AudioClip clip)
//    {
//        sfxSource.PlayOneShot(clip);
//    }

//    public void StopSFX()
//    {
//        if (sfxSource.isPlaying == false)
//            return;

//        sfxSource.Stop();
//    }
//}
