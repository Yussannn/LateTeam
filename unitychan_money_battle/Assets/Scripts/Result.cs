using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Result : MonoBehaviour
{
    int Player1Point = 0,Player2Point = 0;
    int Player1P = 0,Player2P = 0;
    public GameObject Result_Text;  
    public GameObject P1_Text_B,P2_Text_B;
    public Text P1_Point,P2_Point;
    public Text DrawText;
    public Text P1_Winner,P2_Winner;
    public Text OnemoreText;  //①
    public Vector3 p1pos,p2pos;
    public GameObject GoldCoin,SilverCoin;

    public static int p1score = 0, p2score= 0;

    float waitTime = 2.0f;

    bool win1P = false,win2P = false;
    bool Result_T = false;
    bool Player_T = false;
    bool CountStart= false,CountEnd=false;
    bool draw = false;
    bool player1Count = false, player2Count = false;
    bool player1CountReady = false,player2CountReady = false;
    public bool battle = false;　　//①
    public static bool ScEnd = false;
    void Start()
    {
        //Player1Point = PtCalculation.
        win1P = false;
        win2P = false;
        Result_T = false;
        Player_T = false;
        ScEnd = false;
        waitTime = 2.0f;
        P1_Winner.enabled = false;
        P2_Winner.enabled = false;

        Player1Point = PtCalculation.GetPointP1();
        Player2Point = PtCalculation.GetPointP2();
    }

    void Update()
    {

        waitTime -= Time.deltaTime;
        P1_Point.text = Player1P.ToString();
        P2_Point.text = Player2P.ToString();
        if (CountStart && !CountEnd)
        {
            //player1のポイントを2で割ったときの余り
            int p1amari = Player1Point % 2;
            int p2amari = Player2Point % 2;
            if (Player1Point > 1)
            {
                for (int p1 = Player1Point; p1 > 1; p1 -= 2)
                {
                    Instantiate(GoldCoin, p1pos, Quaternion.identity);
                    Player1P += 2;
                }
                player1CountReady = true;
            }
            if (Player2Point > 1)
            {
                for (int p2 = Player2Point; p2 > 1; p2 -= 2)
                {
                    Instantiate(GoldCoin, p2pos, Quaternion.identity);
                    Player2P += 2;
                }
                player2CountReady = true;
            }
            if(p1amari == 1)
            {
                Instantiate(SilverCoin, p1pos, Quaternion.identity);
                Player1P++;
                player1CountReady = true;
            }
            if (p2amari == 1)
            {
                Instantiate(SilverCoin, p2pos, Quaternion.identity);
                Player2P++;
                player2CountReady = true;
            }
            if(Player1Point == 0)
            {
                player1CountReady = true;
            }
            if (Player2Point == 0)
            {
                player2CountReady = true;
            }

            CountEnd = true;
        }
        if (player2CountReady && player1CountReady)
        {
            Invoke("WinText", 2.5f);
        }

        if (CountEnd)
        {
            if (draw)
            {
                Invoke("DrawText_Active",2.5f);
            }
        }

        if (waitTime <= 0.0f)
        {
            BoolUpdate();
        }

        if (Player1Point > Player2Point)
        {
            P1_Winner.text = "1P Win!!";
            P1_Winner.color = new Color(255, 40, 70);
            P2_Winner.text = "2P Lose...";
            P2_Winner.color = new Color(0, 0, 150);
        }
        else if (Player1Point == Player2Point)
        {
            P1_Winner.text = "";
            P2_Winner.text = "";
            draw = true;
        }
        else
        {
            P1_Winner.text = "1P Lose...";
            P1_Winner.color = new Color(0, 0, 150);
            P2_Winner.text = "2P Win!!";
            P2_Winner.color = new Color(255, 40, 70);
        }
    }
    void BoolUpdate()
    {
        Result_T = true;
        waitTime = 1.0f;
        if (Result_T)
        {
            Player_T = true;
            waitTime = 1.0f;　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　
            if (Player_T)
            {
                CountStart = true;
            }
        }
    }

    void WinText()
    {
        P1_Winner.enabled = true;
        P2_Winner.enabled = true;
        Invoke("End",2);
    }
    void DrawText_Active()
    {
        DrawText.color = new Color(DrawText.color.r, DrawText.color.g, DrawText.color.b, 255);
        Invoke("End", 2);
    }

    void End()
    {
        ScEnd = true;
    }
}
