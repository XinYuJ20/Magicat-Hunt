using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetLocation : MonoBehaviour
{
    public float lat;
    public float lon;
    private bool isLocationReady = false;
    private float timeinterval = 5.0f;
    private float currtime = 0.0f;

    void Start()
    {
        // Check if location services are enabled by the user
        if (!Input.location.isEnabledByUser)
        {
            Debug.Log("Location not enabled");
            return;
        }
        Input.location.Start();
        Debug.Log("Starting location services...");

        // Start location services
        
    }

    void Update()
    {
        if (Time.time >= currtime){
            if (Input.location.status == LocationServiceStatus.Stopped){
                Input.location.Start();
                Debug.Log("Attempting to start location services...");
                currtime = Time.time + timeinterval;
                return;
            }   
            // Wait for location services to initialize
            if (Input.location.status == LocationServiceStatus.Initializing)
            {
                Debug.Log("Location services initializing...");
                currtime = Time.time + timeinterval;
                return;
            }

            // Check if location services failed
            if (Input.location.status == LocationServiceStatus.Failed)
            {
                Debug.Log("Location Failed");
                currtime = Time.time + timeinterval;
                return;
            }

            // Once location services are running, update GPS coordinates
            if (Input.location.status == LocationServiceStatus.Running && !isLocationReady)
            {
                // Get the current location
                lat = Input.location.lastData.latitude;
                lon = Input.location.lastData.longitude;
                isLocationReady = true;

                Debug.Log("Latitude: " + lat + " Longitude: " + lon);
                currtime = Time.time + timeinterval;
            }
        }
    }

    void OnDisable()
    {
        // Stop location services when no longer needed
        Input.location.Stop();
        Debug.Log("Stopping location services.");
    }
}
