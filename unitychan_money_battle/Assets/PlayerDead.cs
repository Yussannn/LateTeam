using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerDead : MonoBehaviour
{
    GameObject player1,player2;
    float player1timer,player2timer;
    [SerializeField]GameObject subCamera1, subCamera2;

    void Start()
    {
        player1timer = 3f;
        player2timer = 3f;
        subCamera1.SetActive(false);
        subCamera2.SetActive(false);
        player1.SetActive(true);
        player2.SetActive(true);
    }
    void Update()
    {
        
        player1 = GameObject.Find("UnityChanPlayer0");
        player2 = GameObject.Find("UnityChanPlayer1");

        if (player1) player1timer = 3f;
        else if (player1 == null) player1timer -= Time.deltaTime;

        if (player2) player2timer = 3f;
        else if (player2 == null) player2timer -= Time.deltaTime;

        if (player1timer <= 0) subCamera1.SetActive(true);
        if (player2timer <= 0) subCamera2.SetActive(true);
    }
}
