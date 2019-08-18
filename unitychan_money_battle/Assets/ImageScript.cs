using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine.UI;
using UnityEngine;

public class ImageScript : MonoBehaviour
{
    float time;
    Image abutton;

    public Sprite before;
    public Sprite after;
    private bool Switch;
    void Start()
    {
        time = 1.0f;
        abutton = gameObject.GetComponent<Image>();
    }

    void Update()
    {
        time -= Time.deltaTime;
        if(time <= 0.0f)
        {
            if (!Switch)
            {
                abutton.sprite = after;
                Switch = true;
                time = 1.0f;
            }
            else
            {
                abutton.sprite = before;
                Switch = false;
                time = 1.0f;
            }
        }
    }
}
