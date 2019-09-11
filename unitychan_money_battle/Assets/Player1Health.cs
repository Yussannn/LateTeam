using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player1Health : MonoBehaviour
{
    Slider hpSlider;

    void Start()
    {
        hpSlider = gameObject.GetComponent<Slider>();
    }

    void Update()
    {
        hpSlider.value = PlayerHP.p1Hp;
    }
}
