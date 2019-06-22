using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TimerController : MonoBehaviour
{
    public int TimerCount;

    public Text TimerText;

    public float totalTime;

    int seconds;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("GoTitle", TimerCount); 
    }

    void GoTitle()
    {
        SceneManager.LoadScene("SampleScene_win");
    }     

    // Update is called once per frame
    void Update()
    {
        totalTime -= Time.deltaTime;
        seconds = (int)totalTime;
        TimerText.text = seconds.ToString();
    }
}
