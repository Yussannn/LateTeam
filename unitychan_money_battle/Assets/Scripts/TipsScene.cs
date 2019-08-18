using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TipsScene : MonoBehaviour
{
    float Timer;
    bool onemore;
    bool end;
    bool JoinToStart;
    void Start()
    {
        Timer = 3f;
        onemore = OneMore.Yes;
        end = OneMore.end;
    }

    void Update()
    {
        Timer -= Time.deltaTime;

        if(Timer <= 0.0f)
        {
            if (end)
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
            else
            {
                SceneManager.LoadScene("BlocksStage");
            }
        }
    }
}
