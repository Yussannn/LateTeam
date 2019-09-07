using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemDelete : MonoBehaviour
{
    int itemcol = 5;

    public 
    void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.name == "Floor")
        {
        }
        else
        {
            itemcol--;
        }
    }

    void Update()
    {
        if(Mathf.Approximately(Time.timeScale, 0F))
        {
            return;
        }
        if(itemcol <= 0)
        {
            Destroy(gameObject);
        }
    }
}
