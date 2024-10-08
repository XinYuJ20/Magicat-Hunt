using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    


    [SerializeField]
    private Animator animator;

     public void StartInteraction(){
         Debug.Log("Button Hit"); // yes
        animator.SetTrigger("flowerInteraction"); // Trigger the interaction animation
       
    }
}
