using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleSceneMenu : MonoBehaviour
{
    [SerializeField] Button Yes;
    [SerializeField] Button No;

    void Start()
    {
        Yes = GameObject.Find("YesButton").GetComponent<Button>();
        No = GameObject.Find("NoButton").GetComponent<Button>();
        Yes.Select();
    }
}
