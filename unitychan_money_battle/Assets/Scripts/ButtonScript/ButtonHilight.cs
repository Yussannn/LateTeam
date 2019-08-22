using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonHilight : MonoBehaviour
{
    private GameObject Button;
    private GameObject ButtonBuf;
    private GameObject[] ButtonEffect = new GameObject[2];
    private int i = 0;

    void Update()
    {
        Button = EventSystem.current.currentSelectedGameObject;
        if(i == 0)
        {
            ButtonBuf = Button;
            i++;
        }
        if(Button != ButtonBuf)
        {
            int j = 0;
            foreach(Transform child in Button.transform)
            {
                ButtonEffect[j] = child.gameObject;
                if (j > 0)
                ButtonEffect[j].SetActive(false);
                j++;
            }

            ButtonEffect[0].GetComponent<TextHighlight>().enabled = true;
            j = 0;

            foreach(Transform child in ButtonBuf.transform)
            {
                ButtonEffect[j] = child.gameObject;
                if (j > 0) ButtonEffect[j].SetActive(false);
                j++;
            }

            ButtonEffect[0].GetComponent<TextHighlight>().enabled = false;

            TextMeshProUGUI tmpro = ButtonEffect[0].GetComponent<TextMeshProUGUI>();
            Material material = tmpro.fontMaterial;
            material.SetFloat("_OutlineWidth", 0);
        }

        ButtonBuf = Button;
    }
}
