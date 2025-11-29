using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour 
{
    public CharacterController controller;

    public float speed;
    public float gravity = -9.81f;
    public float jumpheight = 3f;

    //double jump counter 
    public float doublejump = 0;
    public float midaircheck = 0;



    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    Vector3 velocity;
    bool isGrounded;

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
            midaircheck = 0;
            doublejump = 0;
}
        else
        {
            midaircheck = 1;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpheight * -2f * gravity);
        }

        if (Input.GetButtonDown("Jump") && midaircheck == 1 && doublejump == 0)
        {
            velocity.y = Mathf.Sqrt(jumpheight * -2f * gravity);
            doublejump += 1;
        }
        else if (Input.GetButtonDown("Fire3"))
        {
            speed += 6f;
        }
        if (Input.GetButtonUp("Fire3"))
        {
            speed -= 6f;
        }

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }
}
