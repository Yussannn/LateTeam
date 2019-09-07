using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.UI;

public class PoseMenu : MonoBehaviour
{
    bool canpose = false;

    [SerializeField] GameObject pauseUIPrefab;
    GameObject pauseUIInstance;
    [SerializeField] GameObject titleUIPrefab;
    GameObject titleUIInstance;


    void Start()
    {
    }
    void Update()
    {
        canpose = CountDown.CountEnd;

        if (canpose)
        {
            if (CrossPlatformInputManager.GetButtonDown("POSE"))
            {
                if(pauseUIInstance == null)
                {
                    pauseUIInstance = GameObject.Instantiate(pauseUIPrefab) as GameObject;
                    Time.timeScale = 0f;
                }
                else if(titleUIPrefab == null)
                {
                    Destroy(pauseUIInstance);
                    Time.timeScale = 1f;
                }
            }
            if (CrossPlatformInputManager.GetButtonDown("TitleButton"))
            {
                if(pauseUIInstance == null)
                {
                    return;
                }
                else
                {
                    titleUIInstance = GameObject.Instantiate(titleUIPrefab) as GameObject;
                }
            }
        }
    }

    public void Destroy()
    {
        Destroy(titleUIPrefab);
    }
}
