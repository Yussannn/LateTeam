using System.Collections;
using System.Collections.Generic;
using InControl;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityStandardAssets.CrossPlatformInput;
using UnityStandardAssets.Characters.ThirdPerson;
namespace JoinControl
{
    public class JoinControllerScene : MonoBehaviour
    {
        ThirdPersonCharacter tpc;
        ThirdPersonCharacter tpc2;
        ThirdPersonUserControl tpc_Control;
        ThirdPersonUserControl tpc2_Control;
        GameObject player1;
        GameObject player2;
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
            if (GameObject.Find("UnityChanPlayer1"))
            {
                ok = true;
            }
            if (ok)
            {
                if (Input.GetKeyDown(KeyCode.Return) || tpc_Control.Device.Command || tpc2_Control.Device.Command)
                {
                    tpc.salute = true;
                    tpc2.salute = true;
                    timerstart = true;
                }
            }
            if (timerstart)
            {
                time = time - 1 * Time.deltaTime;
            }
            if (time < 0.0f)
            {
                SceneManager.LoadScene("BlocksStage");
            }
            Debug.Log(time);
            Debug.Log(ok);
            Debug.Log("timer" + timerstart);
        }
    }
}