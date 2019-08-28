using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemSprite : MonoBehaviour
{
    public Image Shell;
    public Image Banana;
    public Image Obj;
    void SpriteUPdate(int number)
    {
        if (number == 0)
        {
            Obj.sprite = Shell;
        }
    }
}
