using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class OneMore : MonoBehaviour
{
    bool OneMoreText;
    public static bool Yes;

    public GameObject Image;
    public Text UnderText;
    public Text text;
    public static bool end;

    void Start()
    {
        Image.SetActive(false);
        UnderText.enabled = false;
        text.enabled = false;
        Yes = false;
        end = true;
    }

    void FixedUpdate()
    {
        OneMoreText = Result.ScEnd;
        if (OneMoreText)
        {
            Image.SetActive(true);
            UnderText.enabled = true;
            text.enabled = true;

            if (!Yes)
            {
                if (Input.GetKeyDown(KeyCode.UpArrow))
                {
                    Yes = true;
                    text.text = "Play again?\n\nYes    ←\nNo      ";
                }
                if (Input.GetKeyDown(KeyCode.Return))
                {
                    SceneManager.LoadScene("Ending");
                }
            }
            else
            {
                if (Input.GetKeyDown(KeyCode.DownArrow)){
                    Yes = false;
                    text.text = "Play again?\n\nYes    \nNo     ←";
                }
                if (Input.GetKeyDown(KeyCode.Return))
                {
                    SceneManager.LoadScene("Ending");
                }
            }
        }
    }

}
