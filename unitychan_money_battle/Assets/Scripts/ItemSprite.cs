using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemSprite : MonoBehaviour
{
    GameObject player1,player2;
    public Sprite Shell, Banana; //画像
    ItemUse itemUsep1,itemUsep2; //他スクリプト
    GameObject P1Obj, P2Obj; //オブジェクト
    int p1ItemNumber, p2ItemNumber; 

    void Start()
    {
        P1Obj = GameObject.Find("P1sprite");
        P2Obj = GameObject.Find("P2sprite");
        player1 = GameObject.Find("UnityChanPlayer0");
        player2 = GameObject.Find("UnityChanPlayer1");
    }

    void Update()
    {
        itemUsep1 = player1.GetComponent<ItemUse>();
        itemUsep2 = player2.GetComponent<ItemUse>();
        p1ItemNumber = itemUsep1.p1_ListNumber;
        p2ItemNumber = itemUsep2.p2_ListNumber;
        P1Obj = GameObject.Find("P1sprite");
        P2Obj = GameObject.Find("P2sprite");

        if (Mathf.Approximately(Time.timeScale, 0f))
        {
            return;
        }
        else
        {
            if (p1ItemNumber == 0)
            {
                P1Obj.GetComponent<Image>().sprite = Banana;
            }
            else if (p1ItemNumber == 1)
            {
                P1Obj.GetComponent<Image>().sprite = Shell;
            }
            if (p2ItemNumber == 0)
            {
                P2Obj.GetComponent<Image>().sprite = Banana;
            }
            else if (p2ItemNumber == 1)
            {
                P2Obj.GetComponent<Image>().sprite = Shell;
            }
        }
    }
}
