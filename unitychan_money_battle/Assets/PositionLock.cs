using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PositionLock : MonoBehaviour
{
    Vector3 StartPos;
    Rigidbody rb;

    void Start()
    {
        DontDestroyOnLoad(gameObject);
        rb = gameObject.GetComponent<Rigidbody>();
        rb.constraints =
            RigidbodyConstraints.FreezePositionX |
            RigidbodyConstraints.FreezePositionZ |
            RigidbodyConstraints.FreezeRotation;
    }
    void Update()
    {

    }

    public void LoadScene()
    {
        rb.constraints = RigidbodyConstraints.None;
    }
}
