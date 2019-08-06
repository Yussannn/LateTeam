using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TipsScene : MonoBehaviour
{
    float Timer;
    bool onemore;

    void Start()
    {
        Timer = 3f;
        onemore = OneMore.Yes;
    }

    void Update()
    {
        Timer -= Time.deltaTime;

        if(Timer <= 0.0f)
        {
            if (onemore)
            {
                SceneManager.LoadScene("BlocksStage");
            }
            else
            {
                SceneManager.LoadScene("Title");
            }
        }
    }
}
