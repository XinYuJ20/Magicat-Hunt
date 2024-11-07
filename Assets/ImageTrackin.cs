using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImageTracking : MonoBehaviour
{
    public GameObject[] targets;           // 存放不同的目标对象数组（如 cat, flower_cat 等）
    public GameObject[] trackerImages;     // 存放不同的 Tracker Image 数组，与 targets 一一对应
    public float speed = 5f;
    public float moveDistance = 10f;
    public TextMesh txt;

    private Dictionary<GameObject, GameObject> targetTrackerMap;

    void Start()
    {
        // 建立目标对象与 Tracker Image 的映射关系
        targetTrackerMap = new Dictionary<GameObject, GameObject>();
        for (int i = 0; i < targets.Length; i++)
        {
            if (i < trackerImages.Length)
            {
                targetTrackerMap[targets[i]] = trackerImages[i];
            }
        }
    }

    public void TargetSeen(GameObject target)
    {
        if (targetTrackerMap.ContainsKey(target))
        {
            target.SetActive(true);
            StartCoroutine(MoveTrackerImage(targetTrackerMap[target]));
        }
    }

    public void TargetNotSeen(GameObject target)
    {
        if (targetTrackerMap.ContainsKey(target))
        {
            target.SetActive(false);
            txt.text = "Target lost";
        }
    }

    private IEnumerator MoveTrackerImage(GameObject trackerImage)
    {
        Vector3 cameraDirection = Camera.main.transform.forward;
        Vector3 moveDirection = -cameraDirection;

        Vector3 targetPosition = trackerImage.transform.position + moveDirection * moveDistance;
        while (trackerImage.transform.position != targetPosition)
        {
            trackerImage.transform.position = Vector3.MoveTowards(trackerImage.transform.position, targetPosition, speed * Time.deltaTime);
            yield return null;
        }
    }
}

