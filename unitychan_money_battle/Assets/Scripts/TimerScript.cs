using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimerScript : MonoBehaviour
{
    public float Timer = 30.0f;
    public Text TimerText;
    public GameObject FinishText;
    bool color = false;

    void Start()
    {
        FinishText.SetActive(false);
    }
    void Update()
    {
        if (Timer >= 0.001f)
        {
            Timer = Timer - 1.0f * Time.deltaTime;
        }
        else if(Timer <= 0.0f)
        {
            Timer = 0.0f;
            FinishText.SetActive(true);
            Invoke("ResultSceneMove", 3.5f);
        }
        if (Timer <= 10f)
        {
            TimerText.color = new Color(255, 0, 0, 255);
        }
        TimerText.text = "" + Timer;
    }
    void ResultSceneMove()
    {
        SceneManager.LoadScene("ResultScene");
    }
}
