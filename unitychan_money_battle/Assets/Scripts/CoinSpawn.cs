using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawn : MonoBehaviour
{
    public GameObject gold;
    public GameObject silver;

    float time;

    void Start()
    {
        time = Random.Range(1.0f, 7.0f);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        time = time - 1.0f * Time.deltaTime;

        if(time <= 0.0f)
        {
            int kakuritu = Random.Range(1, 10);
            if(kakuritu > 4)
            {
                Instantiate(silver, transform.position, Quaternion.identity);
                time = Random.Range(1.0f, 9.9f);
            }
            else
            {
                Instantiate(gold, transform.position, Quaternion.identity);
                time = Random.Range(1.0f, 9.9f);
            }
        }
    }
}
