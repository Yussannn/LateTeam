using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemUse : MonoBehaviour
{
    public GameObject item;
    bool Itemusing;
    Vector3 UnityChanPos;
    Vector3 ItemThrow;
    public Transform itempos;
    public float itemspeed = 1000;
    Rigidbody rb;

    void Update()
    {
        Itemusing = true;
        ItemThrow = transform.forward * itemspeed;
        UnityChanPos = gameObject.transform.position;
        if (Itemusing)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                GameObject items = Instantiate(item) as GameObject;
                items.GetComponent<Rigidbody>().AddForce(ItemThrow);
                items.transform.position = itempos.position;
            }
        }
    }
}
