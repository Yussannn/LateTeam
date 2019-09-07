using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class TitleDeleteText : MonoBehaviour
{
    [SerializeField] GameObject pressToStart;
    [SerializeField] GameObject buttonText;
    GameObject buttonTextInstance;
    bool flag;

    //イベント(ボタン)関係
    [SerializeField] GameObject firstSelect;

    void Update()
    {
        if (flag)
        {
            return;
        }
        else if (pressToStart == null)
        {
            buttonTextInstance = GameObject.Instantiate(buttonText) as GameObject;
            flag = true;
        }
        else
        {
            Destroy(buttonTextInstance);
        }
        firstSelect = GameObject.Find("YesButton");
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
}
