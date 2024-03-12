using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadHeart : MonoBehaviour
{
    [SerializeField] Animator animator;

    private void OnEnable()
    {
        animator.SetTrigger("Heart");
    }
}
