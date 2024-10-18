using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarAnimation : MonoBehaviour
{
    private Animator animator;

    [SerializeField]

    // Update is called once per frame
    void StartInteraction()
    {
      animator.SetTrigger("starInteracted");   
    }
}
