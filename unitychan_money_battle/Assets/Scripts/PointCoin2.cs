using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointCoin2 : MonoBehaviour
{
    public static int playerPoint;
    public Text Pointtext2;
    bool coinget;

    void Start()
    {
        playerPoint = 0;
    }
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