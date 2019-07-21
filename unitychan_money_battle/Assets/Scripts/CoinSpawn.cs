using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawn : MonoBehaviour
{
    public GameObject gold;
    public GameObject silver;

    float time = Random.Range(1.0f, 9.9f);
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        time = time - 1.0f * Time.deltaTime;

        if(time <= 0.0f)
        {
            int kakuritu = Random.Range(3, 10);
            if(kakuritu < 3)
            {
                Instantiate(silver, transform.position, Quaternion.identity);
            }
            else
            {
                Instantiate(gold, transform.position, Quaternion.identity);
            }
        }
    }
}
