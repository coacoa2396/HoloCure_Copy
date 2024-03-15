using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FubuLazerRenderer : BossSkill
{
    [SerializeField] FubuLazer lazer;
    [SerializeField] Collider2D coll;
    
    private void Awake()
    {
        lazer = GetComponentInParent<FubuLazer>();
        coll = GetComponent<Collider2D>();        
    }

    private void Start()
    {        
        gameObject.SetActive(false);
    }

    public void ColliderOn()
    {
        ATK = lazer.Fubuzilla.ATK;
        coll.enabled = true;
    }

    public void ColliderOff()
    {
        coll.enabled = false;
    }

    public void Setoff()
    {
        gameObject.SetActive(false);
    }
}
