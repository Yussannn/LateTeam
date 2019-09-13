using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReSpawnTimer : MonoBehaviour
{
    float timer;
    [SerializeField] Text timerText;

    void Start()
    {
        timer = 5f;
    }

    void Update()
    {
        timer -= Time.deltaTime;
        if (timer > 5.0f) timerText.text = "5";
        else if (timer > 4.0f) timerText.text = "4";
        else if (timer > 3.0f) timerText.text = "3";
        else if (timer > 2.0f) timerText.text = "2";
        else if (timer > 1.0f) timerText.text = "1";
        else if (timer >= 0.1f) timerText.text = "0";
       
    }
}
