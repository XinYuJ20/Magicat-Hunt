using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flowerMarkerInteractionTest : MonoBehaviour
{
    private Animator animator;
    private bool isInteracting = false;
    public float interactionDuration = 1.0f; // Time to revert to idle after interaction
    private bool isflowerMarkerDetected = false;

    // Method to call when marker is detected
    public void OnflowerMarkerDetected()
    {
        Debug.Log("flowerMarker detected!");
        isflowerMarkerDetected = true;
    }

    void Start()
    {
        animator = GetComponent<Animator>(); // Get the Animator component attached to the sprite
    }


    void Update()
    {   
        if (isflowerMarkerDetected)
        {
            StartInteraction();
        }         
    }

    // Method to call when the marker is lost
    public void OnflowerMarkerLost()
    {
        Debug.Log("flowerMarker lost!");
        isflowerMarkerDetected = false;
    }

    void StartInteraction()
    {
        isInteracting = true;
        animator.SetTrigger("isInteracted"); // Trigger the interaction animation
        Invoke("EndInteraction", interactionDuration); // Wait before returning to idle
    }

    void EndInteraction()
    {
        isInteracting = false;
    }

}



