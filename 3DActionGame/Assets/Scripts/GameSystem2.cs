using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSystem2 : MonoBehaviour
{
    // Start is called before the first frame update
    public void GameEnd()
    {
        SceneManager.LoadScene("SampleScene._title");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
