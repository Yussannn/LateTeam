using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParentObj : MonoBehaviour
{
    [SerializeField] GameObject pauseObj;
    void Start()
    {
        pauseObj = GameObject.Find("PauserObj");
    }
    void Update()
    {
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
        foreach(var player in players)
        {
            player.transform.parent = pauseObj.transform;
        }
        GameObject[] goldcoins = GameObject.FindGameObjectsWithTag("GoldColin");
        foreach(var gcoin in goldcoins)
        {
            gcoin.transform.parent = pauseObj.transform;
        }
        GameObject[] silvercoins = GameObject.FindGameObjectsWithTag("SilverCoin");
        foreach(var scoin in silvercoins)
        {
            scoin.transform.parent = pauseObj.transform;
        }
        GameObject[] items = GameObject.FindGameObjectsWithTag("Item");
        foreach(var item in items)
        {
            item.transform.parent = pauseObj.transform;
        }
    }
}
