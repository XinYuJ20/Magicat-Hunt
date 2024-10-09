using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocationAnimation1 : MonoBehaviour
{
    // the lodge
    public float lat_target = 43.061391f;
    public float lon_target = -77.692833f;
    public float error = 50.0f; //meters 
    private Animator animator;
    private GetLocation getlocat;



    // Start is called before the first frame update
    void Start()
    {
        getlocat = GetComponent<GetLocation>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (getlocat != null){
            float lat = getlocat.lat;
            float lon = getlocat.lon;
            float radius_earth = 6371000;
            float delta_lat = Mathf.Deg2Rad * (lat_target - lat);
            float delta_lon = Mathf.Deg2Rad * (lon_target - lon);
            // haversine distance calculation
            float hav1 = Mathf.Sin(delta_lat / 2) * Mathf.Sin(delta_lat / 2) + 
                Mathf.Cos(Mathf.Deg2Rad * lat) * Mathf.Cos(Mathf.Deg2Rad * lat_target) *
                Mathf.Sin(delta_lon / 2) * Mathf.Sin(delta_lon / 2);
            float hav2 = Mathf.Asin(hav1);
            float distance = 2 * radius_earth * hav2;

            if (distance <= error){
                animator.SetTrigger("isInteracted");
            }


        }
    }
}
