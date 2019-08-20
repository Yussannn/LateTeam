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
    GameObject player1,player2;
    ControllerChecks conSc;
    bool color = false;
    bool finish;

    bool gameStart;

    void Start()
    {
        FinishText.SetActive(false);
        player1 = GameObject.Find("UnityChanPlayer0");
        player2 = GameObject.Find("UnityChanPlayer1");
        player1.GetComponent<ThirdPersonUserControl>().enabled = false;
        player2.GetComponent<ThirdPersonUserControl>().enabled = false;
        player1.GetComponent<ItemUse>().enabled = false;
        player2.GetComponent<ItemUse>().enabled = false;
        player1.GetComponent<PointCoin>().enabled = false;
        player2.GetComponent<PointCoin>().enabled = false;
    }
    void FixedUpdate()
    {
        gameStart = CountDown.CountEnd;
        if (gameStart)
        {
            Timer -= Time.deltaTime;

            player1.GetComponent<ThirdPersonUserControl>().enabled = true;
            player2.GetComponent<ThirdPersonUserControl>().enabled = true;
            player1.GetComponent<ItemUse>().enabled = true;
            player2.GetComponent<ItemUse>().enabled = true;
            player1.GetComponent<PointCoin>().enabled = true;
            player2.GetComponent<PointCoin>().enabled = true;
        }
        if(Timer <= 0.1f)
        {
            finish = true;

            player1.GetComponent<ThirdPersonUserControl>().enabled = false;
            player2.GetComponent<ThirdPersonUserControl>().enabled = false;
            player1.GetComponent<ItemUse>().enabled = false;
            player2.GetComponent<ItemUse>().enabled = false;
            player1.GetComponent<PointCoin>().enabled = false;
            player2.GetComponent<PointCoin>().enabled = false;
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
