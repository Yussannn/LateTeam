﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemUse : MonoBehaviour        // 1 P 専 用
{
    int MaxValue; //アイテムの種類
    public GameObject A_Item;
    public GameObject B_Item;

    private List<GameObject> ItemList = new List<GameObject>();

    void Start()
    {
        ItemList.Add(A_Item);
        ItemList.Add(B_Item);
        MaxValue = ItemList.Count;
    }

    void Update()
    {
        //Rキーを押して、選んで、MAxvalueと同じ値で0に戻す！
    }

    /*
    public GameObject A_item;
    public GameObject B_item;
    bool Itemusing;
    Vector3 UnityChanPos;
    Vector3 ItemThrow;
    public Transform itempos;
    public float itemspeed = 100;
    Rigidbody rb;

    int ItemNumber;

    void Update()
    {
        Itemusing = true;
        ItemThrow = transform.forward * itemspeed;
        UnityChanPos = gameObject.transform.position;
        if (Input.GetKeyDown(KeyCode.R))
        {
            if(ItemNumber == 2)
            {

            }
        }

        if (ItemNumber == 1)
        {
            ItemThrow = transform.forward * itemspeed;
        }
        else if (ItemNumber == 2)
        {
            //ItemThrow = -transform.forward * itemspeed;  //置き型アイテムだからいらん
        }

        if (Itemusing)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (ItemNumber == 1)
                {
                    GameObject items = Instantiate(A_item) as GameObject;
                    items.GetComponent<Rigidbody>().AddForce(ItemThrow);
                    items.transform.position = itempos.position;
                }
                else if (ItemNumber == 2)
                {
                    GameObject items = Instantiate(B_item) as GameObject;
                    //items.GetComponent<Rigidbody>().AddForce(ItemThrow); //置き型アイテムだからいらん
                    items.transform.position = itempos.position;
                }
            }
        }
    }
    */
}
