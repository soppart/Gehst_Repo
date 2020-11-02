using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JohnPlayerMove : MonoBehaviour
{

    public int speed = 4;
    public int jumpForce = 800;
    Rigidbody2D _rigidbody;
    Animator _animator;

    public LayerMask groundlayer;
    public Transform feetPoint;
    public bool grounded;

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

        grounded = Physics2D.OverlapCircle(feetPoint.position, .5f, groundlayer);
        if (Input.GetButtonDown("Jump") && grounded)
        {
            _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, 0);
            _rigidbody.AddForce(new Vector2(0, jumpForce));
        }
        _animator.SetBool("Grounded", grounded);
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
