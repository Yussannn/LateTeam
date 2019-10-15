using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VariableDifinition : MonoBehaviour
{
    public static GameObject player1, player2;
    public static GameObject sub_camera1, sub_camera2;

    void Start()
    {
        player1 = GameObject.Find("UnityChanPlayer0");
        player2 = GameObject.Find("UnityChanPlayer1");
        sub_camera1 = GameObject.Find("1P_SubCamera");
        sub_camera2 = GameObject.Find("2P_SubCamera");
    }
}
