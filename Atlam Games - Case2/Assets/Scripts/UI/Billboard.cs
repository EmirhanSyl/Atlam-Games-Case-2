using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboard : MonoBehaviour
{
    private Transform cam;
    void Start()
    {
        cam = Camera.main.transform;
        GetComponent<Canvas>().worldCamera = Camera.main;
    }


    void LateUpdate()
    {
        transform.LookAt(cam.position);
    }
}
