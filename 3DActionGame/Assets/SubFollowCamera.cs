using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public GameObject player;
    public Vector3 playerVec;
    public Vector3 vec;

    void Start()
    {
    }

    void Update()
    {
        playerVec = player.transform.position;
        transform.position = new Vector3(playerVec.x, playerVec.y + 5f, playerVec.z - 10f);
    }
}
