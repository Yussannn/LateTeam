using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Textfall : MonoBehaviour
{
    Vector3 pos;
    Vector3 objectPos;
    public float delayTime = 1f;
    public float speed = 1f;

    void Start()
    {
        pos = new Vector3(GetComponent<RectTransform>().localPosition.x, 0, 0);
        
    }

    void Update()
    {
        float step = speed * Time.deltaTime;

        delayTime = delayTime - 1 * Time.deltaTime;

        if(delayTime <= 0.0f)
        {
            GetComponent<RectTransform>().localPosition = Vector3.MoveTowards(GetComponent<RectTransform>().localPosition, pos, step);
        }
    }
}
