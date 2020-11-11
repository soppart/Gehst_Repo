﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JohnPlayerMove : MonoBehaviour
{

    public int speed = 4;
    public int jumpForce = 800;
    Rigidbody2D _rigidbody;
    Animator _animator;

    public LayerMask groundlayer;
   // public LayerMask enemylayer;
    public Transform feetPoint;
    public bool grounded;
    public bool secondJump;

    private HealthManager _healthManager;


    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _healthManager = FindObjectOfType<HealthManager>();
    }

  
    void Update()
    {
        float xSpeed = Input.GetAxisRaw("Horizontal") * speed;
        _rigidbody.velocity = new Vector2(xSpeed, _rigidbody.velocity.y);
        _animator.SetFloat("Speed", Mathf.Abs(xSpeed));

        if ((xSpeed < 0 && transform.localScale.x > 0) ||(xSpeed > 0 && transform.localScale.x < 0))
        {
            transform.localScale *= new Vector2(-1, 1);
        }

        //check for grounded
       // grounded = Physics2D.OverlapCircle(feetPoint.position, .5f, groundlayer);
            grounded = Physics2D.OverlapCircle(feetPoint.position, .4f, groundlayer);
        
        if (grounded)
        {
            secondJump = true;
            _animator.SetBool("jump",false);
            _animator.SetBool("jump2",false);
            _animator.SetBool("grounded", true);
        }
        else
        {
            _animator.SetBool("grounded", false);
        }

        if (Input.GetKeyDown(KeyCode.W) /* Input.GetKeyDown(KeyCode.UpArrow)*/ && grounded)
        { 
            _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, 0);
            _rigidbody.AddForce(new Vector2(0, jumpForce));
            _animator.SetBool("jump",true);
            
        }
        
        else if(Input.GetKeyDown(KeyCode.W) && !grounded && secondJump)
        {
            _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, 0);
            _rigidbody.AddForce(new Vector2(0, jumpForce));
            _animator.SetBool("jump",false);
            _animator.SetBool("jump2",true);
            
            secondJump = false;
        }

    

        if (!grounded)
        {
           _animator.SetBool("grounded", false);
        }
       _animator.SetBool("grounded", grounded);
    }



    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            _healthManager.RemoveHealth(1);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
       

        if (other.CompareTag("health"))
        {
            _healthManager.AddHealth();
            Destroy(other.gameObject);
        }
    }
}
