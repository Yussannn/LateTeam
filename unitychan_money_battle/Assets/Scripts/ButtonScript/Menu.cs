using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    Button Yes;
    Button No;

    void Start()
    {
        Yes = GameObject.Find("/ButtonCanvas/YesButton").GetComponent<Button>();
        No = GameObject.Find("/ButtonCanvas/NoButton").GetComponent<Button>();

        Yes.Select();
    }
}
