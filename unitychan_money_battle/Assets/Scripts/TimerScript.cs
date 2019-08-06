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
    GameObject Player1;
    GameObject Player2;
    bool color = false;
    bool finish;

    void Start()
    {
        FinishText.SetActive(false);
        Player1 = GameObject.FindWithTag("Player1");
        Player2 = GameObject.FindWithTag("Player2");
    }
    void FixedUpdate()
    {
        Timer -= Time.deltaTime;
        if(Timer <= 0.1f)
        {
            finish = true;
            Player1.GetComponent<ThirdPersonUserControl>().enabled = false;
            Player1.GetComponent<ItemUse>().enabled = false;
            Player1.GetComponent<ThirdPersonCharacter>().enabled = false;
            Player1.GetComponent<PointCoin>().enabled = false;
            Player2.GetComponent<ThirdPersonUserControl>().enabled = false;
            Player2.GetComponent<ItemUse>().enabled = false;
            Player2.GetComponent<ThirdPersonCharacter>().enabled = false;
            Player2.GetComponent<PointCoin2>().enabled = false;
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
        Debug.Log(finish);
        TimerText.text = Timer.ToString();
    }
    void ResultSceneMove()
    {
        SceneManager.LoadScene("ResultScene");
    }
}
