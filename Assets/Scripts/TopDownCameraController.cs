using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownCameraController : MonoBehaviour
{
    public Vector3 cameraOffset;
    public Transform target;

    // Update is called once per frame
    void Update()
    {
        if (target) {
            transform.position = target.position + cameraOffset;
        }
    }
}