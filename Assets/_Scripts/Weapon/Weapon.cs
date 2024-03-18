using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : PooledObject
{
    public int atk;
    public int level;

    public void LevelUp()
    {
        atk += 10;
        level++;

        if (level > 7 )
        {
            level = 7;
            atk += 5;
        }
    }
}
