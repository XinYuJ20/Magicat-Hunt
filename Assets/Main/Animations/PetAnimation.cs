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
        // Check for touch or mouse click
        if (Input.touchCount > 0 || Input.GetMouseButtonDown(0))
        {
            Vector3 touchPosition;

            if (Input.touchCount > 0)
            {
                touchPosition = Input.GetTouch(0).position; // Get touch position
            }
            else
            {
                touchPosition = Input.mousePosition; // For testing in editor
            }

            // Convert touch/mouse position to a world point

            var newRay = Camera.main.ScreenPointToRay(touchPosition);

            var hit = Physics2D.GetRayIntersection(newRay);

            // Check if the ray hit a collider and if it is the current game object
            if (hit.collider != null && hit.collider.gameObject == gameObject)
            {
                Debug.Log("Touched on: " + hit.collider.gameObject.name + "at " + touchPosition);
                StartInteraction();
            }
        }
    }

    void StartInteraction()
    {
        isInteracting = true;
        animator.SetTrigger("isInteracted"); // Trigger the interaction animation
    }
}
