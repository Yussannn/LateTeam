using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointCoin : MonoBehaviour
{
    int playerPoint = 0;
    void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.name == "goldcoin")
        {
            Destroy(col.gameObject);
            playerPoint += 2;
        }
        else if(col.gameObject.name == "silvercoin")
        {
            Destroy(col.gameObject);
            playerPoint += 1;
        }
    }
}
