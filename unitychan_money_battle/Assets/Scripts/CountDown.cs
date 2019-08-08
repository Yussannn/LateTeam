using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class CountDown : MonoBehaviour
{
    float count = 2f;
    bool Ready;
    public static bool CountEnd;
    public Text text;
    public Text text2;
    public Text text3;
    int a_color;
    void Start()
    {
        Ready = false;
        a_color = 255;
    }
    void Update()
    {
        text.color = new Color(text.color.r, text.color.g, text.color.b, a_color);
    }
    void FixedUpdate()
    {
        count -= Time.deltaTime;
        if(!Ready && count <= 0.0f)
        {
            text.text = "5";
            count = 5.0f;
            Ready = true;
        }
        if(Ready && count <= 4.0f)
        {
            text.text = "4";
        }
        if (Ready && count <= 3.0f)
        {
            text.text = "3";
        }
        if (Ready && count <= 2.0f)
        {
            text.text = "2";
        }
        if (Ready && count <= 1.0f)
        {
            text.text = "1";
        }
        if (Ready && count <= 0.0f)
        {
            text.text = "Start";
            CountEnd = true;
            Invoke("Delete", 3.0f);
        }
    }

    void Delete()
    {
        text.GetComponent<CountDown>().enabled = false;
        text.enabled = false;
        text2.enabled = false;
        text3.enabled = false;
    }
}
