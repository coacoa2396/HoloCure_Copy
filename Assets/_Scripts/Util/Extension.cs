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
        // ������ �������� ��ȯ
        float radAngle = angle * Mathf.Deg2Rad;

        // ������ �κ�: cos�� sin�� ������ �ٲ���
        float sin = Mathf.Sin(radAngle);
        float cos = Mathf.Cos(radAngle);

        // ������ �κ�: x�� y�� ������ �ٲ���
        return new Vector2(sin, cos);
    }


}
