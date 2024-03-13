using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Diagnostics;

public class PsychoAxe : Bullet
{
    [SerializeField] float speed;
    [SerializeField] float angle;
    [SerializeField] float radius;

    public Vector2 initPosition;
    public ParticleSystem ps;

    protected override void Awake()
    {
        speed = 350f;
        angle = 270f;
        radius = 0.5f;
        ps = GetComponentInChildren<ParticleSystem>();
    }

    private void OnEnable()
    {
        initPosition = transform.position;
    }

    protected override void Update()
    {
        StrikeOperate();

        // ��ƼŬ�ý��� ȸ������
        if (ps != null)
        {
            ParticleSystem.MainModule main = ps.main;

            if (main.startRotation.mode == ParticleSystemCurveMode.Constant)
            {
                main.startRotation = -transform.eulerAngles.z * Mathf.Deg2Rad;
            }
        }

        transform.Rotate(0, 0, 3f, Space.World);
    }

    


    
    private void StrikeOperate()
    {
        angle += speed * Time.deltaTime;
        radius += radius * Time.deltaTime;
        Vector2 direction = Extension.GetClockwiseVector(angle);
        Vector2 nextSpiralOffset = direction * radius;

        transform.position = initPosition + nextSpiralOffset;
    }
    
}
