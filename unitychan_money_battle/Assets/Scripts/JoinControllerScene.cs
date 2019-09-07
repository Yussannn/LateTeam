using System.Collections;
using System.Collections.Generic;
using InControl;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityStandardAssets.CrossPlatformInput;
using UnityStandardAssets.Characters.ThirdPerson;
public class JoinControllerScene : MonoBehaviour
{
    ThirdPersonCharacter tpc, tpc2;
    ThirdPersonUserControl tpc_Control, tpc2_Control;
    PositionLock posLock, posLock2;

    GameObject player1, player2;
    [HideInInspector] public float time = 5.0f;
    bool timerstart;
    bool ok;

    void Start()
    {
    }
    void Update()
    {
        player1 = GameObject.Find("UnityChanPlayer0");
        player2 = GameObject.Find("UnityChanPlayer1");


        tpc = player1.GetComponent<ThirdPersonCharacter>();
        tpc2 = player2.GetComponent<ThirdPersonCharacter>();
        tpc_Control = player1.GetComponent<ThirdPersonUserControl>();
        tpc2_Control = player2.GetComponent<ThirdPersonUserControl>();
        posLock = player1.GetComponent<PositionLock>();
        posLock2 = player2.GetComponent<PositionLock>();

        Debug.Log(time);
        Debug.Log(ok);
        Debug.Log("timer" + timerstart);

        if (player2)
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                tpc.salute = true;
                tpc2.salute = true;
                Invoke("LoadScene", 5.0f);
            }
            if (tpc_Control.Device.Command || tpc2_Control.Device.Command)
            {
                tpc.salute = true;
                tpc2.salute = true;
                Invoke("LoadScene", 5.0f);
            }
        }
    }
    void LoadScene()
    {
        posLock.LoadScene();
        posLock2.LoadScene();
        posLock.enabled = false;
        posLock2.enabled = false;
        SceneManager.LoadScene("BlocksStage");
    }
}