using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDestroy : MonoBehaviour
{
    GameObject Obj;
    public int times=5; //あたり回数
    void Start()
    {
        Obj = this.gameObject;
    }

    void Update()
    {
        if(times == 0)
        {
            Destroy(gameObject);
        }
    }
    
    void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.tag == "floor")
        {
        }
        else if(col.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }
        else
        {
            times--;
        }
    }
}
