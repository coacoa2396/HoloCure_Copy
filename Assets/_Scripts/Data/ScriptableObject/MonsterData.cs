using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MonsterData", menuName = "Data/Monster")]
public class MonsterData : ScriptableObject
{

    public Monster prefab;

    [Serializable]
    public class MonsterInfo
    {
        public string name;
        public string description;

    }

}
