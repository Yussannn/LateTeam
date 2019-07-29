using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TipsScene : MonoBehaviour
{
    float Timer;

    void Start()
    {
        Timer = 3f;
    }

    void Update()
    {
        Timer -= 1 * Time.deltaTime;

        if(Timer <= 0.0f)
        {
            SceneManager.LoadScene("Title");
        }
    }
}
