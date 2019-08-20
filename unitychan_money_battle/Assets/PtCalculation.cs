using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PtCalculation : MonoBehaviour
{
    [HideInInspector] public int Player1Pt,Player2Pt;

    public Text player1Text,player2Text;
    
    void Start()
    {

    }
    void Update()
    {
        player1Text.text = Player1Pt.ToString();
        player2Text.text = Player2Pt.ToString();
    }

    public void SilverAddPoint(GameObject obj)
    {
        const int point = 1;
        if(obj.name == "UnityChanPlayer0")
        {
            Player1Pt += point;
        }
        else if(obj.name == "UnityChanPlayer1")
        {
            Player2Pt += point;
        }
    }

    public void GoldAddPoint(GameObject obj)
    {
        const int point = 2;
        if (obj.name == "UnityChanPlayer0")
        {
            Player1Pt += point;
        }
        else if (obj.name == "UnityChanPlayer1")
        {
            Player2Pt += point;
        }
    }
}
