using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FanBeamInit : Weapon, IActiveCheck
{
    [SerializeField] Bullet prefab;    
    [SerializeField] PlayerController player;
    [SerializeField] GameObject pivot;

    [SerializeField] float interval;

    float timer;

    private void Awake()
    {
        timer = 0f;
        player = GetComponentInParent<PlayerController>();
    }    

    private void Update()
    {

        timer += Time.deltaTime;

        if (timer > interval)
        {
            FlipCheck();
            timer = 0f;
            FanBeamSetOn();
        }
    }

    void FanBeamSetOn()
    {
        prefab.gameObject.SetActive(true);

        Manager.Sound.PlaySFX("FanBeam");
    }

    void FlipCheck()
    {
        if (player.spriter.flipX)
        {
            pivot.transform.rotation = Quaternion.Euler(0, 0, 180);
        }
        else
        {
            pivot.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }
}
