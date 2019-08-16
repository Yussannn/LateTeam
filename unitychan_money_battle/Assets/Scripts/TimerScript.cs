using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityStandardAssets.Characters.ThirdPerson;

public class TimerScript : MonoBehaviour
{
    public float Timer = 30.0f;
    public Text TimerText;
    public GameObject FinishText;
    GameObject playerObj;
    ControllerChecks conSc;
    bool color = false;
    bool finish;

    bool gameStart;

    void Start()
    {
        FinishText.SetActive(false);
        for (var players = 0; players < conSc.players.Count; players++)
        {
            playerObj = GameObject.Find("UnityChanPlayer" + players);
            playerObj.GetComponent<ThirdPersonUserControl>().enabled = false;
            playerObj.GetComponent<ItemUse>().enabled = false;
            playerObj.GetComponent<ThirdPersonCharacter>().enabled = false;
            playerObj.GetComponent<PointCoin>().enabled = false;
        }
    }
    void FixedUpdate()
    {
        gameStart = CountDown.CountEnd;
        if (gameStart)
        {
            Timer -= Time.deltaTime;
            for (var players = 0; players < conSc.players.Count; players++)
            {
                playerObj = GameObject.Find("UnityChanPlayer" + players);
                playerObj.GetComponent<ThirdPersonUserControl>().enabled = true;
                playerObj.GetComponent<ItemUse>().enabled = true;
                playerObj.GetComponent<ThirdPersonCharacter>().enabled = true;
                playerObj.GetComponent<PointCoin>().enabled = true;
            }
            /*
            Player1.GetComponent<ThirdPersonUserControl>().enabled = true;
            Player1.GetComponent<ItemUse>().enabled = true;
            Player1.GetComponent<ThirdPersonCharacter>().enabled = true;
            Player1.GetComponent<PointCoin>().enabled = true;
            Player2.GetComponent<ThirdPersonUserControl>().enabled = true;
            Player2.GetComponent<ItemUse>().enabled = true;
            Player2.GetComponent<ThirdPersonCharacter>().enabled = true;
            Player2.GetComponent<PointCoin2>().enabled = true;
            */
        }
        if(Timer <= 0.1f)
        {
            finish = true;
            for (var players = 0; players < conSc.players.Count; players++)
            {
                playerObj = GameObject.Find("UnityChanPlayer" + players);
                playerObj.GetComponent<ThirdPersonUserControl>().enabled = false;
                playerObj.GetComponent<ItemUse>().enabled = false;
                playerObj.GetComponent<ThirdPersonCharacter>().enabled = false;
                playerObj.GetComponent<PointCoin>().enabled = false;
            }
        }
        if (Timer <= 10f)
        {
            TimerText.color = new Color(255, 0, 0, 255);
        }
        if (finish)
        {
            Timer = 0.0f;
            FinishText.SetActive(true);
            Invoke("ResultSceneMove", 3.5f);
        }
        TimerText.text = Timer.ToString();
    }
    void ResultSceneMove()
    {
        SceneManager.LoadScene("ResultScene");
    }
}
