using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody rb;
    public float speed = 3f;
    public float thrust = 200;
    private Animator anim;
    Vector3 p_Pos;
    bool ground;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        p_Pos = transform.position;
    }

    void Update()
    {
        if (ground)
        {
            float x = Input.GetAxisRaw("Horizontal") * Time.deltaTime * speed;
            float z = Input.GetAxisRaw("Vertical") * Time.deltaTime * speed;

            rb.MovePosition(transform.position + new Vector3(x, 0, z));
            Vector3 dir = transform.position - p_Pos;
            if (dir.magnitude > 0.01f)
            {
                transform.rotation = Quaternion.LookRotation(new Vector3(dir.x, 0, dir.z));
                anim.SetBool("Running", true);
            }
            else
            {
                anim.SetBool("Running", false);
            }

            p_Pos = transform.position;
            if (Input.GetButton("Jump"))
            {
                rb.AddForce(transform.up * thrust);
                if(rb.velocity.magnitude > 0)
                {
                    rb.AddForce(transform.forward * thrust/2 + transform.up * thrust);
                }
            }
        }

    }
    void OnCollisionStay(Collision col)
    {
        ground = true;
        anim.SetBool("Jumping", false);
    }

    void OnCollisionExit(Collision col)
    {
        ground = false;
        anim.SetBool("Jumping", true);
    }
}
