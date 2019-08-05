using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointCoin : MonoBehaviour
{
    public static int playerPoint;
    public Text Pointtext;
    bool coinget;

    void Start()
    {
        playerPoint = 0;
    }

    void Update()
    {
        Pointtext.text = "" + playerPoint;
        Debug.Log(playerPoint);
    }

    void OnCollisionEnter(Collision col)
    {
        coinget = false;
        if (col.gameObject.tag == "GoldColin" && !coinget)
        {
            Destroy(col.gameObject);
            playerPoint += 2;
            coinget = true;
        }
        else if (col.gameObject.tag == "SilverCoin" && !coinget)
        {
            Destroy(col.gameObject);
            playerPoint++;
            coinget = true;
        }
    }
}
