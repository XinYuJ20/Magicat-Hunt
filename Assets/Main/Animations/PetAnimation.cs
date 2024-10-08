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
            
            touchPosition.z = 12;
            // Convert the touch/mouse position to a world point
            var worldPoint = Camera.main.ScreenToWorldPoint(touchPosition);
            
            var camPosition = Camera.main.transform.position;
            var camDirection = worldPoint - camPosition;
            var newRay =  new Ray(camPosition, camDirection);   

            var hit = Physics2D.GetRayIntersection(newRay);

            if (hit.collider != null ){
                Debug.Log("Touched on: " + hit.collider.gameObject.name); // yes
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


    

