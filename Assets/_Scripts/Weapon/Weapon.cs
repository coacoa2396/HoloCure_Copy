using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : PooledObject
{
    public int atk = 99;
    public int level = 1;

    public void LevelUp()
    {
        atk += 99;
        level++;

        if (level > 7 )
        {
            level = 7;
            atk += 5;
        }
    }
}
