using UnityEngine;
using TMPro;

public class DebugLogger : MonoBehaviour
{
    public TextMeshProUGUI debugText;  // Reference to TextMeshProUGUI component

    void OnEnable()
    {
        // Subscribe to the log callback
        Application.logMessageReceived += HandleLog;
    }

    void OnDisable()
    {
        // Unsubscribe to the log callback
        Application.logMessageReceived -= HandleLog;
    }

    // This method will be called every time Debug.Log is triggered
    void HandleLog(string logString, string stackTrace, LogType type)
    {
        if (debugText != null)
        {
            // **Clear the text each time a new log is received**
            debugText.text = "";  // Reset the text

            // Display the new log message
            debugText.text = logString;  // Set the new message
        }
    }

    void Start()
    {
        if (debugText == null)
        {
            Debug.LogError("TextMeshProUGUI is not assigned.");
            return;
        }
        debugText.text = "Debugging start...";
    }

    void Update()
    {
        // Check for touch or mouse click
        if (Input.touchCount > 0 || Input.GetMouseButtonDown(0))
        {
            Debug.Log("Screen touched at: " + Input.mousePosition);
        }
    }
}
