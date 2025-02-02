using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float jumpHeight = 3;
    public Transform feet;
    public LayerMask groundmask;
    public float speed = 15;
    public float gravity = -9.8f;

    private CharacterController controller;
    private bool isGrounded;
    private float y;
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    
    void Update()
    {   isGrounded = Physics.CheckSphere(feet.position, 0.4f,groundmask);

        //cap gravity
        if (isGrounded) y = 0;
        

        var input = new Vector3();
        input.x = Input.GetAxis("Horizontal");
        input.z = Input.GetAxis("Vertical");

        var move = (transform.right * input.x  + transform.forward * input.z)
            * speed * Time.deltaTime;

        //jump
        if (isGrounded&&Input.GetKeyDown(KeyCode.Space))
        {
            y = MathF.Sqrt(jumpHeight * -2f * gravity)*Time.deltaTime;
        }


        //add gravity
        y += gravity * Time.deltaTime * Time.deltaTime;
        move.y = y;


        controller.Move(move);




    }
    private void OnDrawGizmos()
    {
        if (feet != null) { 
            Gizmos.color = Color.blue;
            Gizmos.DrawWireSphere(feet.position, 0.4f);
        
        
        }

    }



}
