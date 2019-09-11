using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHP : MonoBehaviour
{
    [HideInInspector]public const int p1MaxHP = 100, p2MaxHP = 100;
    public static int p1Hp, p2Hp;
    [HideInInspector]public static GameObject player1, player2;
    void Start()
    {
        p1Hp = p1MaxHP;p2Hp = p2MaxHP;
        player1 = GameObject.Find("UnityChanPlayer0");
        player2 = GameObject.Find("UnityChanPlayer1");
    }
    
    void Update()
    {
        if(p1Hp <= 0)
        {
            Dead(player1);
        }
        if(p2Hp <= 0)
        {
            Dead(player2);
        }
    }
    public static void p1TakeDamage(int damage)
    {
        p1Hp -= damage;
        if(p1Hp <= 0)
        {
            Dead(player1);
        }
    }

    public static void p2TakeDamage(int damage)
    {
        p2Hp -= damage;
        if(p2Hp <= 0)
        {
            Dead(player2);
        }
    }

    void Recovery(GameObject player)
    {
        if (player == player1)
        {
            p1Hp = p1MaxHP;
        }
        else if(player == player2)
        {
            p2Hp = p2MaxHP;
        }
    }

    void ReSpawn(GameObject player)
    {
        player.SetActive(true);
    }

    public static void Dead(GameObject player)
    {
        player.SetActive(false);
    }
}
