using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    private CharacterController p_contorol;
    private Animator animCon;
    public float speed = 5.0f;
    public float rotationSpeed = 1200.0f;

    private const float gravityPower = 9.8f;
    public Rigidbody rb;

    public void Hit()
    {
    }

    void Start()
    {
        p_contorol = GetComponent<CharacterController>();
        animCon = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if(Input.GetAxis("Vertical") == 0 && Input.GetAxis("Horizontal") == 0)
        {
            animCon.SetBool("Walking", false);
        }

        else
        {
            var cameraForward = Vector3.Scale(Camera.main.transform.forward, new Vector3(1, 0, 1)).normalized;
            Vector3 direction = cameraForward * Input.GetAxis("Vertical") + Camera.main.transform.right * Input.GetAxis("Horizontal");
            animCon.SetBool("Walking", true);

            ChangeDirection(direction);
            Move(direction);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(0, 5, 0);
        }

        //アクション処理を追加していく
        // 例 : animCon.SetBool("Action", Input.GetKey("x") || Input.GetButtonDown("Action"));

    }

    void ChangeDirection(Vector3 dir)
    {
        Quaternion q = Quaternion.LookRotation(dir);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, q, rotationSpeed * Time.deltaTime);
    }

    void Move(Vector3 dis)
    {
        rb.AddForce(dis * Time.deltaTime * speed);
    }
}
