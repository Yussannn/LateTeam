using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationCoin : MonoBehaviour
{
    public float angle;
    void Update()
    {
        angle += 1f * Time.deltaTime;
        this.transform.Rotate(0f,angle,0f);
    }
}
