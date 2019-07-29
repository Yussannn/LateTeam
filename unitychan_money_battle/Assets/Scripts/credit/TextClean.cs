using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TextClean : MonoBehaviour
{

    public Text Qtext;
    bool a_Qtext;
    public Text Attention;
    bool a_Attention;
    public Text AtText;
    bool a_AtText;
    bool a_flag;
    bool a_flag2;
    float a_color;
    float a_color2;
    float DelayTime = 3.0f;
    // Use this for initialization
    void Start()
    {
        a_flag = false;
        a_flag2 = false;
        a_color = 0;
        a_color2 = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //a_flagがfalseの間実行する
        if (!a_flag && !a_Qtext)
        {
            //テキストの透明度を変更する
            Qtext.color = new Color(255, 255, 255, a_color);
            a_color += Time.deltaTime;
            //透明度が0になったら終了する。
            if (a_color > 1)
            {
                a_flag = true;
            }
        }
        if (a_flag && !a_Qtext)
        {
            DelayTime = DelayTime - 1 * Time.deltaTime;
        }
        if (DelayTime <= 0.0f && !a_Qtext)
        {
            //テキストの透明度を変更する
            Qtext.color = new Color(255, 255, 255, a_color);
            a_color -= Time.deltaTime;
            //透明度が0になったら終了する。
            if (a_color < 0)
            {
                a_color = 0;
                DelayTime = 2f;
                a_Qtext = true;
            }
        }
        if (a_Qtext)
        {
            //a_flagがfalseの間実行する
            if (!a_flag2)
            {
                //テキストの透明度を変更する
                Attention.color = new Color(255, 66, 64, a_color);
                a_color += Time.deltaTime;
                //透明度が0になったら終了する。
                if (a_color > 1)
                {
                    a_flag2 = true;
                }
            }
            if (a_flag2)
            {
                DelayTime = DelayTime - 1 * Time.deltaTime;
            }
            if (DelayTime <= 0.0f)
            {
                //テキストの透明度を変更する
                AtText.color = new Color(255, 255, 255, a_color2);
                a_color2 += Time.deltaTime;
                //透明度が0になったら終了する。
                if (a_color2 >= 1)
                {
                    a_color2 = 1;
                    if (Input.GetKeyDown(KeyCode.Return))
                    {
                        SceneManager.LoadScene("Title");
                    }
                }
            }
        }
    }
}