using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    [SerializeField]Button Yes;
    [SerializeField]Button No;

    void Start()
    {
        Yes = GameObject.Find("/TitleButtonCanvas(Clone)/YesButton").GetComponent<Button>();
        No = GameObject.Find("/TitleButtonCanvas(Clone)/NoButton").GetComponent<Button>();
        Yes.Select();
    }

    
}
