using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocationAnimation1 : MonoBehaviour
{
    // the library
    public float lat_target = 43.08419f;
    public float lon_target = -77.67631f;
    public float error = 100.0f; //meters 
    private float distance = 0.0f;
    private Animator animator;
    private GetLocation getlocat;
    private float timeinterval = 5.0f;
    private float currtime = 0.0f;



    // Start is called before the first frame update
    void Start()
    {
        getlocat = GetComponent<GetLocation>();
        animator = GetComponent<Animator>();

        
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= currtime) {
            if (getlocat != null){
                float lat = getlocat.lat;
                float lon = getlocat.lon;
                //float lat = Input.location.lastData.latitude;
                //float lon = Input.location.lastData.longitude;
                float radius_earth = 6371000;
                float delta_lat = Mathf.Deg2Rad * (lat_target - lat);
                float delta_lon = Mathf.Deg2Rad * (lon_target - lon);
                // haversine distance calculation
                float hav1 = Mathf.Sin(delta_lat / 2) * Mathf.Sin(delta_lat / 2) + 
                    Mathf.Cos(Mathf.Deg2Rad * lat) * Mathf.Cos(Mathf.Deg2Rad * lat_target) *
                    Mathf.Sin(delta_lon / 2) * Mathf.Sin(delta_lon / 2);
                float hav2 = Mathf.Asin(hav1);
                distance = 2 * radius_earth * hav2;

                // for testing purposes distance = 0
                if (distance <= error){
                    Debug.Log("within distance of location. distance:" + distance + ", lonlat: "+ lon + " " + lat);
                    animator.SetTrigger("isInteracted");
                } else{
                    Debug.Log("distance = " + distance + "lonlat= " + lon + " " + lat);
                }  
                currtime = Time.time + timeinterval;
                
            }
        }
    }
}
