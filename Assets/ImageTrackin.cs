using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImageTrackin : MonoBehaviour
{
    public GameObject cat;
    public GameObject TrakerImage;
    public float speed = 5f;
    public float moveDistance = 10f;
    public TextMesh txt;

    public void TargetSeen()
    {
        
        cat.SetActive(true);
        StartCoroutine(MoveTrakerImage());
    }

    public void TargetNotSeen()
    {
        cat.SetActive(false);
        txt.text = "Target lost";
    }

    private IEnumerator MoveTrakerImage()

    {
        Vector3 cameraDirection = Camera.main.transform.forward;
        Vector3 moveDirection = -cameraDirection;

        Vector3 targetPosition = TrakerImage.transform.position + moveDirection * moveDistance;
        while (TrakerImage.transform.position != targetPosition)
        {
            TrakerImage.transform.position = Vector3.MoveTowards(TrakerImage.transform.position, targetPosition, speed * Time.deltaTime);
            yield return null;
        }
    }
}
