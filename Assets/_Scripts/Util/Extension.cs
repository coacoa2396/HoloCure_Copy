using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public static class Extension
{
    public static bool Contain(this LayerMask layerMask, int layer)
    {
        return ((1 << layer) & layerMask) != 0;
    }

    public static Vector2 GetClockwiseVector(float angle)
    {
        // 각도를 라디안으로 변환
        float radAngle = angle * Mathf.Deg2Rad;

        // 수정된 부분: cos와 sin의 순서를 바꿔줌
        float sin = Mathf.Sin(radAngle);
        float cos = Mathf.Cos(radAngle);

        // 수정된 부분: x와 y의 순서를 바꿔줌
        return new Vector2(sin, cos);
    }


}
