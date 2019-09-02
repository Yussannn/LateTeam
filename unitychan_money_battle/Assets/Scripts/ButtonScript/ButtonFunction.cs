using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonFunction : MonoBehaviour
{
    GameObject scriptsObj;
    public void StringArgFunction(string s)
    {
        SceneManager.LoadScene(s);
    }

    public void Tutorial(bool tutorial)
    {

    }
}
