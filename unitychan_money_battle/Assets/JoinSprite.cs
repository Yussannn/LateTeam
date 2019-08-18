using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.ThirdPerson;
using InControl;

public class JoinSprite : MonoBehaviour
{
    public GameObject canvas1;
    public GameObject canvas2;
    public GameObject canvas3;
    public GameObject canvas4;
    ControllerChecks con;
    void Update()
    {
        if(GameObject.Find("UnityChanPlayer0"))
        {
            canvas1.SetActive(false);
        }
        if(GameObject.Find("UnityChanPlayer1"))
        {
            canvas2.SetActive(false);
            canvas3.SetActive(false);
            canvas4.SetActive(true);
        }
    }
}
