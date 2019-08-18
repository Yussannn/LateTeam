using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPosition : MonoBehaviour
{
    Vector3 p1pos;
    Vector3 p2pos;
    Vector3 p2Rot;
    GameObject player1;
    GameObject player2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        player1 = GameObject.Find("UnityChanPlayer0");
        player2 = GameObject.Find("UnityChanPlayer1");

        p1pos = new Vector3(0, 0.5f, -18);
        p2pos = new Vector3(0, 0.5f, 18);
        p2Rot = new Vector3(0, 180, 0);
        player1.transform.position = p1pos;
        player2.transform.position = p2pos;
        player2.transform.Rotate(p2Rot);
    }
}
