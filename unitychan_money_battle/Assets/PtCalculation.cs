using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PtCalculation : MonoBehaviour
{
    [HideInInspector] public int Player1Pt;
    [HideInInspector] public int Player2Pt;
    [HideInInspector] public int Player3Pt;
    [HideInInspector] public int Player4Pt;

    public Text player1Text;
    public Text player2Text;
    public Text player3Text;
    public Text player4Text;
    
    void Start()
    {

    }
    void Update()
    {
        player1Text.text = Player1Pt.ToString();
        player2Text.text = Player2Pt.ToString();
    }

    public void SilverAddPoint(string playername)
    {
        const int point = 1;
        switch (playername) {
            case "UnityChanPlayer0":
                Player1Pt += point;
                break;
            case "UnityChanPlayer1":
                Player2Pt += point;
                break;
            case "UnityChanPlayer2":
                Player3Pt += point;
                break;
            case "UnityChanPlayer3":
                Player4Pt += point;
                break;
        }
    }

    public void GoldAddPoint(string playername)
    {
        const int point = 2;
        switch (playername)
        {
            case "UnityChanPlayer0":
                Player1Pt += point;
                break;
            case "UnityChanPlayer1":
                Player2Pt += point;
                break;
            case "UnityChanPlayer2":
                Player3Pt += point;
                break;
            case "UnityChanPlayer3":
                Player4Pt += point;
                break;
        }
    }
}
