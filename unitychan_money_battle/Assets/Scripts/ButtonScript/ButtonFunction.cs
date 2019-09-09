using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonFunction : MonoBehaviour
{
    GameObject scriptsObj;
    [SerializeField] GameObject firstSelect;
    GameObject PauseCancelUIInstanse;

    private void Start()
    {
        PauseCancelUIInstanse = GameObject.Find("BackButtonCanvas(Clone)");
    }

    public void ActivateOrNotActivate(bool flag)
    {
        for(var i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).GetComponent<Button>().interactable = flag;
        }
        if (flag)
        {
            EventSystem.current.SetSelectedGameObject(firstSelect);
        }
    }
    public void StringArgFunction(string s)
    {
        SceneManager.LoadScene(s);
    }

    public void Tutorial(bool tutorial)
    {

    }

    public void Cancel()
    {
        SceneManager.LoadScene("Ending");
    }

    public void Destroy()
    {
        Destroy(PauseCancelUIInstanse);
    }
}
