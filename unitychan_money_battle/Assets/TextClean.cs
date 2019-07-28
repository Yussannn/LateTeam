using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TextClean : MonoBehaviour
{

    public Text Qtext;
    bool a_flag;
    float a_color;
    float DelayTime = 3.0f;
    // Use this for initialization
    void Start()
    {
        a_flag = false;
        a_color = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //a_flagがfalseの間実行する
        if (!a_flag)
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
        if (a_flag)
        {
            DelayTime = DelayTime - 1 * Time.deltaTime;
        }
        if(DelayTime <= 0.0f)
        {
            //テキストの透明度を変更する
            Qtext.color = new Color(255, 255, 255, a_color);
            a_color -= Time.deltaTime;
            //透明度が0になったら終了する。
            if (a_color < 0)
            {
                a_color = 0;
                SceneManager.LoadScene("Title");
            }
        }
    }
}