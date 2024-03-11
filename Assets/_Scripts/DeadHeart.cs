using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadHeart : MonoBehaviour
{
    [SerializeField] Animation animation;
    

    private void OnEnable()
    {
        animation.Play();
    }
}
