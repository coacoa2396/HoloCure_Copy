using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallAmeGroundPound : BossSkill
{
    [SerializeField] SmallAme smallAme;
    

    private void Awake()
    {
        smallAme = GetComponentInParent<SmallAme>();
        
    }

    private void Start()
    {
        ATK = smallAme.ATK;
    }

    
    
}
