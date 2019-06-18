using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform a_target;
    public float a_smoothing = 5f;

    Vector3 a_offset;


    // Use this for initialization
    void Start()
    {
        a_offset = transform.position + a_offset;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 targetCamPos = a_target.position + a_offset;
        transform.position = Vector3.Lerp(transform.position, targetCamPos, a_smoothing * Time.deltaTime);
    }
}
