using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointCoin : MonoBehaviour
{
    PtCalculation colsc;
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "GoldColin")
        {
            Destroy(col.gameObject);
            colsc.GoldAddPoint(gameObject.name);
        }
        else if (col.gameObject.tag == "SilverCoin")
        {
            Destroy(col.gameObject);
            colsc.SilverAddPoint(gameObject.name);
        }
    }
}
