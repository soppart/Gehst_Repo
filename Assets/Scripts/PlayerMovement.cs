﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public CharacterController2D controller;
     public Animator animator;

    public float runSpeed = 40f;

     float horizontalMove = 0f;
    

    bool jump = false;


    // Update is called once per frame
    void Update()
    {

     horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));
       
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            Debug.Log("up");
            jump = true;
           animator.SetBool("isJumping", true);
         

        }

    }

    public void OnLanding()
    {
        // if velocity not positive 
       
        Debug.Log("landed");
        animator.SetBool("isJumping", false);
    }

    void FixedUpdate()
    {
        // Move our character
        controller.Move(horizontalMove * Time.fixedDeltaTime, jump);
        jump = false;

    }
}
