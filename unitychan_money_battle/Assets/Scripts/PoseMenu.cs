using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PoseMenu : MonoBehaviour
{
    bool canpose = false;

    [SerializeField] GameObject pauseUIPrefab;
    GameObject pauseUIInstance;
    [SerializeField] GameObject titleUIPrefab;
    GameObject titleUIInstance;
    bool flag;
    [SerializeField] GameObject firstSelect;

    Pausable pausable;

    void Start()
    {
        pausable = GameObject.Find("PauserObj").GetComponent<Pausable>();
    }
    void Update()
    {
        canpose = CountDown.CountEnd;

        if (canpose)
        {
            if (CrossPlatformInputManager.GetButtonDown("POSE"))
            {
                if (pauseUIInstance == null)
                {
                    pauseUIInstance = GameObject.Instantiate(pauseUIPrefab) as GameObject;
                    pausable.pausing = true;
                }
                else if (titleUIPrefab == null)
                {
                    Destroy(pauseUIInstance);
                    pausable.pausing = false;
                }
                else
                {
                    Destroy(pauseUIInstance);
                    pausable.pausing = false;
                }
            }
            if (CrossPlatformInputManager.GetButtonDown("TitleButton"))
            {
                if(pauseUIInstance == null)
                {
                    return;
                }
                else if(titleUIInstance == null)
                {
                    titleUIInstance = GameObject.Instantiate(titleUIPrefab) as GameObject;
                    firstSelect = GameObject.Find("YesButton");
                }
            }
        }
    } 
    public void ActivateOrNotActivate(bool flag)
    {
        for (var i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).GetComponent<Button>().interactable = flag;
        }
        if (flag)
        {
            EventSystem.current.SetSelectedGameObject(firstSelect);
        }
    }

    public void Destroy()
    {
        Destroy(titleUIPrefab);
    }
}
