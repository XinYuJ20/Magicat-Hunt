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

            // Convert touch/mouse position to world point
            Vector3 worldPoint = Camera.main.ScreenToWorldPoint(touchPosition);
            Vector2 worldPoint2D = new Vector2(worldPoint.x, worldPoint.y); // Use only X and Y for 2D raycast

            // Perform a raycast in 2D
            RaycastHit2D hit = Physics2D.Raycast(worldPoint2D, Vector2.zero);

            // Check if the ray hit a collider
            if (hit.collider != null)
            {
                Debug.Log("Touched on: " + hit.collider.gameObject.name); // yes
                StartInteraction();
            }
        }
    }

    void StartInteraction()
    {
        animator.SetTrigger("isInteracted"); // Trigger the interaction animation
    }
}

    

