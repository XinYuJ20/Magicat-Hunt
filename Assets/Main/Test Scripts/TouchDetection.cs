using UnityEngine;
using TMPro; // For TextMeshPro

public class TouchDetection : MonoBehaviour
{
    public TextMeshProUGUI debugText; // For displaying touch info in UI

    void Update()
    {
        // Check for touch input
        if (Input.touchCount > 0)
        {
            debugText.text = ""; // Reset the text
            Touch touch = Input.GetTouch(0); // Get the first touch

            // Clear the previous message and display the new touch information
            if (debugText != null)
            {
                debugText.text = ""; // Reset the text
                debugText.text = "Touch Detected: Position - " + touch.position;
            }

            // Log touch information in console
            Debug.Log("Touch Detected: Position - " + touch.position);

            // You can also check for the specific phase of the touch
            if (touch.phase == TouchPhase.Began)
            {
                Debug.Log("Touch Phase: Began");
                if (debugText != null)
                    debugText.text += "\nTouch Phase: Began";
            }
            else if (touch.phase == TouchPhase.Ended)
            {
                Debug.Log("Touch Phase: Ended");
                if (debugText != null)
                    debugText.text += "\nTouch Phase: Ended";
            }
        }
        else
        {
            // Clear the text when no touch is detected
            if (debugText != null)
            {
                debugText.text = "No touch detected";
            }
        }
    }
}
