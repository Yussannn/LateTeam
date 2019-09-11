using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColiderScript: MonoBehaviour
{
    PtCalculation colsc;
    GameObject colscObj;
    
    void Update()
    {
        colscObj = GameObject.Find("ScriptsObj");
        colsc = colscObj.GetComponent<PtCalculation>();
    }
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "GoldColin")
        {
            Destroy(col.gameObject);
            colsc.GoldAddPoint(gameObject);
        }
        else if (col.gameObject.tag == "SilverCoin")
        {
            Destroy(col.gameObject);
            colsc.SilverAddPoint(gameObject);
        }

        if(col.gameObject.name == "bananaKai(Clone)")
        {
            if(gameObject.name == "UnityChanPlayer0")
            {
                PlayerHP.p1TakeDamage(20);
            }
            else
            {
                PlayerHP.p2TakeDamage(20);
            }
        }
        if(col.gameObject.name == "Shell(Clone)")
        {
            if(gameObject.name == "UnityChanPlayer0")
            {
                PlayerHP.p1TakeDamage(30);
            }
            else
            {
                PlayerHP.p2TakeDamage(30);
            }
        }
    }
}
