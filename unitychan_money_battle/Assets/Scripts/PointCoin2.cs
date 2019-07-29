using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointCoin2 : MonoBehaviour
{
    int playerPoint = 0;
    public Text Pointtext2;
    bool coinget;

    void Update()
    {
        Pointtext2.text = "" + playerPoint;
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