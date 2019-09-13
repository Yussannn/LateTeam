using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.CrossPlatformInput;
using InControl;

public class Player1_ReSpawn : MonoBehaviour
{
    List<Vector3> reSpawnPoint = new List<Vector3>
    {
        new Vector3(0,130,0),  // W
        new Vector3(0,-130,0), // S
        new Vector3(130,0,0),  // D
        new Vector3(-130,0,0)  // A
    };

    RectTransform markerPoint; //マーカー(画像)の現座標
    [SerializeField] Image reSpawnUIImage; //マーカー本体
    public static int point;

    void Start()
    {
        point = 1;
    }

    void Update()
    {
        markerPoint = reSpawnUIImage.GetComponent<RectTransform>();
        

        if (point == 1) markerPoint.localPosition = reSpawnPoint[0];
        else if (point == 2) markerPoint.localPosition = reSpawnPoint[3];
        else if (point == 3) markerPoint.localPosition = reSpawnPoint[1];
        else if (point == 4) markerPoint.localPosition = reSpawnPoint[2];

        float v = CrossPlatformInputManager.GetAxis("AD_1");
        float h = CrossPlatformInputManager.GetAxis("WS_1");
        if (h > 0) point = 1;
        else if (h < 0) point = 3;
        else if (v < 0) point = 2;
        else if (v > 0) point = 4;
    }
}
