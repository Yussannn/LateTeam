using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SpaceToStart: MonoBehaviour
{

    //public
    public float speed = 1.0f;

    //private
    private Text text;
    private Image image;
    private float time;
    //bool destroySwitch;
    public static bool destroyCheck;


    //いきなりバトル
    bool battle_flag;

    private enum ObjType
    {
        TEXT,
        IMAGE
    };
    private ObjType thisObjType = ObjType.TEXT;

    void Start()
    {
        //destroySwitch = false;
        destroyCheck = false;

        //アタッチしてるオブジェクトを判別
        if (this.gameObject.GetComponent<Image>())
        {
            thisObjType = ObjType.IMAGE;
            image = this.gameObject.GetComponent<Image>();
        }
        else if (this.gameObject.GetComponent<Text>())
        {
            thisObjType = ObjType.TEXT;
            text = this.gameObject.GetComponent<Text>();
        }

        battle_flag = false;
    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            speed = 10.0f;
            Invoke("DestroyOfSwitch", 2.5f);
        }
        if (Input.GetKeyDown(KeyCode.Space) && Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.RightShift))
        {
            speed = 10.0f;
            Invoke("DestroyOfSwitch", 2.5f);
            battle_flag = true;
        }

        //オブジェクトのAlpha値を更新
        if (thisObjType == ObjType.IMAGE)
        {
            image.color = GetAlphaColor(image.color);
        }
        else if (thisObjType == ObjType.TEXT)
        {
            text.color = GetAlphaColor(text.color);
        }
    }

    void DestroyOfSwitch()
    {
        Destroy(gameObject);
        destroyCheck = true;
        if (!battle_flag)
        {
            SceneManager.LoadScene("Tutorial");
        }
        if (battle_flag)
        {
            SceneManager.LoadScene("BlocksStage");
        }
    }

    //Alpha値を更新してColorを返す
    Color GetAlphaColor(Color color)
    {
        time += Time.deltaTime * 5.0f * speed;
        color.a = Mathf.Sin(time) * 0.5f + 0.5f;

        return color;
    }
}