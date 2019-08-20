using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPosition : MonoBehaviour
{
    Vector3 p1pos,p2pos,p1Rot,p2Rot;
    GameObject player1,player2;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("PositionSet", 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        player1 = GameObject.Find("UnityChanPlayer0");
        player2 = GameObject.Find("UnityChanPlayer1");

        p1pos = new Vector3(0, 0.5f, -18);
        p2pos = new Vector3(0, 0.5f, 18);
        p1Rot = new Vector3(0, 180, 0);
        p2Rot = new Vector3(0, 0, 0);
    }

    void PositionSet()
    {
        player1.transform.position = p1pos;
        player2.transform.position = p2pos;
        player1.transform.Rotate(p1Rot);
        player2.transform.Rotate(p2Rot);
    }
}
