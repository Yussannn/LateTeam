using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlloerChecks : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var contollersNames = Input.GetJoystickNames();

        if(contollersNames[0] == "")
        {
            Debug.Log("エラー 接続されてるコントローラーが見つかりません");
        }
    }
}
