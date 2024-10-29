using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class textbox : MonoBehaviour
{
    public GameObject targetObject;   
    public TextMeshProUGUI textBox;   


    // Start is called before the first frame update
    void Start()
    {
        textBox.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (targetObject.activeInHierarchy)
        {
            textBox.gameObject.SetActive(true);
        }
        else
        {
            textBox.gameObject.SetActive(false);
        }
    }
}


