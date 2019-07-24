using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerScript : MonoBehaviour
{
    public float Timer = 30.0f;
    public Text TimerText;
    bool color = false;
    void Update()
    {
        if (Timer >= 0.001f)
        {
            Timer = Timer - 1.0f * Time.deltaTime;
        }
        else if(Timer <= 0.0f)
        {
            Timer = 0.0f;
        }
        if (Timer <= 10f)
        {
            TimerText.color = new Color(255, 0, 0, 255);
        }
        TimerText.text = "" + Timer;
    }
}
