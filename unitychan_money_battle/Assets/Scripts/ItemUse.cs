using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.UI;

public class ItemUse : MonoBehaviour
{
    public GameObject Banana_item,Shell_item; //生成するオブジェクト

    private bool p1selected,p2selected; //選択スイッチ

    public Transform Forward,Backward;
    //public Transform P2_Forward,P2_Backward; //生成する位置

    public float speed = 1000; //アイテムのスピード

    private bool usetimep1, usetimep2;

    public static int Item_p1_B = 99, Item_p2_B = 99, Item_p1_S = 99, Item_p2_S = 99; //初期アイテム所持数
    public static int maxItem = 5; //アイテム最大所持数

    public int p1_ListNumber = 0,p2_ListNumber=0;
    //private int selectNumberP1,selecteNumberP2;
    private float select_NumberP1,select_NumberP2;
    private const int MaxValue = 2;

    private List<GameObject> ItemList = new List<GameObject>(); //アイテムリスト
    private GameObject settingObjectP1; //選択されてるオブジェクト
    private GameObject settingObjectP2;

    ItemUse itemUse;
    //public int P1number, P2number;
    void Start()
    {
        ItemList.Add(Banana_item);
        ItemList.Add(Shell_item);
    }

    void Update()
    {
        if (Mathf.Approximately(Time.timeScale, 0f))
        {
            return;
        }
        else
        {
            if (!p1selected && CrossPlatformInputManager.GetButtonDown("Item_Select_P1"))
            {
                p1selected = true;
                select_NumberP1 = CrossPlatformInputManager.GetAxisRaw("Item_Select_P1");
            }
            if (!p2selected && CrossPlatformInputManager.GetButtonDown("Item_Select_P2"))
            {
                p2selected = true;
                select_NumberP2 = CrossPlatformInputManager.GetAxisRaw("Item_Select_P2");
            }

            if (p2selected)
            {
                if (CrossPlatformInputManager.GetButtonUp("Item_Select_P2"))
                {
                    p2selected = false;
                }
            }
            if (select_NumberP1 > 0)
            {
                if (p1_ListNumber == MaxValue - 1) p1_ListNumber = 0;
                else p1_ListNumber++;
            }
            else if (select_NumberP1 < 0)
            {
                if (p1_ListNumber == 0) p1_ListNumber = MaxValue - 1;
                else p1_ListNumber--;
            }

            if (select_NumberP2 > 0)
            {
                if (p2_ListNumber == MaxValue - 1) p2_ListNumber = 0;
                else p2_ListNumber++;
            }
            else if (select_NumberP2 < 0)
            {
                if (p2_ListNumber == 0) p2_ListNumber = MaxValue - 1;
                else p2_ListNumber--;
            }

            if (CrossPlatformInputManager.GetButton("Item_Use_P1"))
            {
                if (!usetimep1)
                {
                    P1_ItemUse(settingObjectP1);
                    usetimep1 = true;
                }

            }
            if (CrossPlatformInputManager.GetButtonUp("Item_Use_P1"))
            {
                usetimep1 = false;
            }
            if (CrossPlatformInputManager.GetButton("Item_Use_P2"))
            {
                if (!usetimep2)
                {
                    P2_ItemUse(settingObjectP2);
                    usetimep2 = true;
                }
            }
            if (CrossPlatformInputManager.GetButtonUp("Item_Use_P2"))
            {
                usetimep2 = false;
            }
        }

            if (gameObject.name == "UnityChanPlayer0")
                settingObjectP1 = ItemList[p1_ListNumber];
            else if (gameObject.name == "UnityChanPlayer1")
                settingObjectP2 = ItemList[p2_ListNumber];


            if (Item_p1_B > maxItem) Item_p1_B = maxItem; if (Item_p1_S > maxItem) Item_p1_S = maxItem;
            if (Item_p2_B > maxItem) Item_p2_B = maxItem; if (Item_p2_S > maxItem) Item_p2_S = maxItem;

    }

    void P1_ItemUse(GameObject obj)
    {
        if(obj == Banana_item && Item_p1_B > 0)
        {
            GameObject itemsP1 = Instantiate(obj) as GameObject;
            itemsP1.transform.position = Backward.position;
            Item_p1_B--;
        }
        else if(obj == Shell_item && Item_p1_S > 0)
        {

            GameObject itemsP1 = Instantiate(obj) as GameObject;
            Vector3 force;
            force = gameObject.transform.forward * speed;
            itemsP1.GetComponent<Rigidbody>().AddForce(force);
            itemsP1.transform.position = Forward.position;
            Item_p1_S--;
        }
    }

    void P2_ItemUse(GameObject obj)
    {
        
        if(obj == Banana_item && Item_p2_B > 0)
        {
            GameObject itemsP2 = Instantiate(obj) as GameObject;
            itemsP2.transform.position = Backward.position;
            Item_p2_B--;
        }
        else if(obj == Shell_item && Item_p2_S > 0)
        {
            GameObject itemsP2 = Instantiate(obj) as GameObject;
            Vector3 force;
            force = gameObject.transform.forward * speed;
            itemsP2.GetComponent<Rigidbody>().AddForce(force);
            itemsP2.transform.position = Forward.position;
            Item_p2_S--;
        }
    }

    void FixedUpdate()
    {
        select_NumberP1 = 0;
        p1selected = false;
        select_NumberP2 = 0;
        p2selected = false;
    }
}
