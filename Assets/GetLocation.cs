using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetLocation : MonoBehaviour
{

    public float lat;
    public float lon;

    IEnumerator Start()
    {
        if (!Input.location.isEnabledByUser)
            yield break;

        Input.location.Start();

        int wait = 30;
        while (Input.location.status == LocationServiceStatus.Initializing && wait > 0) {
            yield return new WaitForSeconds(1);
            wait--;
        }
        if (wait < 1) {
            Debug.Log("Time Out");
            yield break;
        }

        if (Input.location.status == LocationServiceStatus.Failed) {
            Debug.Log("Location Fail");
            yield break;
        } else {
            lat = Input.location.lastData.latitude;
            lon = Input.location.lastData.longitude;
            Debug.Log("Lat: " + lat + " Lon: " + lon);
        }

        Input.location.Stop();

    }

}
