using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public float deleteTimer = 10.0f;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(this, deleteTimer);
    }

    // Update is called once per frame
    void Update()
    {
        if(Mathf.Approximately(Time.timeScale, 0f))
        {
            return;
        }
        transform.Rotate(new Vector3(0,5,0));
    }
}
