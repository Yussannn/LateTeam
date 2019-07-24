﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointCoin : MonoBehaviour
{
    int playerPoint = 0;
    public Text Pointtext;
    bool coinget;

    void Update()
    {
        Pointtext.text = "" + playerPoint;
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
            playerPoint += 1;
            coinget = true;
        }
    }
}
