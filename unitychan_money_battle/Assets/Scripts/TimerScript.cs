using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityStandardAssets.Characters.ThirdPerson;

public class TimerScript : MonoBehaviour
{
    public float Timer = 180.0f;
    public Text TimerText;
    public GameObject FinishText;
    GameObject player1,player2;
    ControllerChecks conSc;
    bool color = false;
    bool finish = false;

    bool gameStart = false;

    void Start()
    {
        player1 = GameObject.Find("UnityChanPlayer0");
        player2 = GameObject.Find("UnityChanPlayer1");

        FinishText.SetActive(false);
        player1.SetActive(true);
        player2.SetActive(true);

        player1.GetComponent<ThirdPersonUserControl>().enabled = false;
        player2.GetComponent<ThirdPersonUserControl>().enabled = false;
        player1.GetComponent<ItemUse>().enabled = false;
        player2.GetComponent<ItemUse>().enabled = false;
        player1.GetComponent<ColiderScript>().enabled = false;
        player2.GetComponent<ColiderScript>().enabled = false;
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
            player1.GetComponent<ColiderScript>().enabled = true;
            player2.GetComponent<ColiderScript>().enabled = true;
        }
        if(Timer <= 0.1f)
        {
            finish = true;

            player1.GetComponent<ThirdPersonUserControl>().enabled = false;
            player2.GetComponent<ThirdPersonUserControl>().enabled = false;
            player1.GetComponent<ItemUse>().enabled = false;
            player2.GetComponent<ItemUse>().enabled = false;
            player1.GetComponent<ColiderScript>().enabled = false;
            player2.GetComponent<ColiderScript>().enabled = false;
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
        Destroy(GameObject.FindWithTag("Item"));
        Destroy(GameObject.FindWithTag("SilverCoin"));
        Destroy(GameObject.FindWithTag("GoldColin"));
        SceneManager.LoadScene("ResultScene");
        player1.SetActive(false);
        player2.SetActive(false);
    }
}
