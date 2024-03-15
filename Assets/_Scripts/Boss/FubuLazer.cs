using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FubuLazer : MonoBehaviour
{
    [SerializeField] public Boss Fubuzilla;
    [SerializeField] SpriteRenderer FubuzillaRenderer;
    [SerializeField] Animator animator;
    [SerializeField] GameObject rendererObject;

    [SerializeField] float interval;

    float timer;

    private void Awake()
    {
        animator = GetComponentInChildren<Animator>();
        rendererObject = GetComponentInChildren<SpriteRenderer>().gameObject;
        Fubuzilla = GetComponentInParent<Boss>();
        Debug.Log(Fubuzilla);
        interval = 7f;
    }

    private void Start()
    {
        FubuzillaRenderer = Fubuzilla.spriter;

    }

    private void Update()
    {
        timer += Time.deltaTime;

        if (timer > interval)
        {
            rendererObject.SetActive(true);
            timer = 0f;
            animator.Play("FubuLazer");
        }
    }

    private void LateUpdate()
    {
        FlipCheck();
    }

    void FlipCheck()
    {
        if (FubuzillaRenderer.flipX)
        {
            transform.rotation = Quaternion.Euler(0, 0, 180);
        }
        else
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }
}
