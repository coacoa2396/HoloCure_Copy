using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public static class Extension
{
    public static bool Contain(this LayerMask layerMask, int layer)
    {
        return ((1 << layer) & layerMask) != 0;
    }
    
}
