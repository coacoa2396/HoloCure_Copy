using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FanBeamInit : MonoBehaviour, IActiveCheck
{
    [SerializeField] Bullet prefab;
    [SerializeField] Bullet fanBeam;
    [SerializeField] PlayerController player;

    [SerializeField] float interval;

    float timer;

    private void Awake()
    {
        timer = 0f;
        player = GetComponentInParent<PlayerController>();
    }

    private void OnEnable()
    {
        fanBeam = Instantiate(prefab
            , new Vector3(transform.position.x + 8, transform.position.y, transform.position.z)
            , transform.rotation);
        
        fanBeam.gameObject.SetActive(true);
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

    private void LateUpdate()
    {

    }

    void FanBeamSetOn()
    {
        if (player.spriter.flipX)
        {
            transform.rotation = Quaternion.Euler(0, 0, 180);
        }
        else
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }

        fanBeam = Instantiate(prefab
                , new Vector3(transform.position.x + 8, transform.position.y, transform.position.z)
                , transform.rotation);
        
        fanBeam.gameObject.SetActive(true);


        Manager.Sound.PlaySFX("FanBeam");
    }

    void FlipCheck()
    {
        if (player.spriter.flipX)
        {
            transform.rotation = Quaternion.Euler(0, 0, 180);
        }
        else
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }
}
