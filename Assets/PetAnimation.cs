using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetAnimation : MonoBehaviour
{
    private Animator animator;
    private bool isInteracting = false;
    public float interactionDuration = 1.0f; // Time to revert to idle after interaction

    void Start()
    {
        animator = GetComponent<Animator>(); // Get the Animator component attached to the sprite
    }

    void Update()
    {
        
        if (Input.touchCount > 0 || Input.GetMouseButtonDown(0))
        {
            Vector2 touchPosition;
            
            if (Input.touchCount > 0) 
            {
                touchPosition = Input.GetTouch(0).position;
            }
            else 
            {
                touchPosition = Input.mousePosition; // For testing in editor with mouse click
            }

            // Convert the touch position to world position
            Vector2 worldPoint = Camera.main.ScreenToWorldPoint(touchPosition);
            
            // Check if the touch is on the sprite
            Collider2D collider = Physics2D.OverlapPoint(worldPoint);
            if (collider != null && collider.gameObject == gameObject && !isInteracting)
            {
                StartInteraction();
            }
        }
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

