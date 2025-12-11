using System;
using System.Drawing;
using Unity.Mathematics;
using UnityEngine;
public class PlayerInput : MonoBehaviour
{
    private float horizontal;
    private float speed = 8f;
    private float jumpingPower = 16f;
    private bool isFacingRight = true;
    private bool isGrounded = false;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal") * speed;

        animator.SetFloat("Speed", Mathf.Abs(horizontal));

        if (horizontal != 0)
        {
            animator.SetBool("isRunning", true);
        }

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocityX, jumpingPower);
            isGrounded = false;
            animator.SetBool("isGrounded", !isGrounded);
            animator.SetBool("isRunning", false);
}

        if (Input.GetButtonUp("Jump") && rb.linearVelocityY > 0f)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocityX, rb.linearVelocityY * 0.5f);
        }

        Flip();
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(horizontal * speed, rb.linearVelocityY);
    }

    private void Flip()
    {
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 ls = transform.localScale;
            ls.x *= -1f;
            transform.localScale = ls;
        }
    }
}

/*      float x = 0;
        float y = 0;
        //float z = 0;

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            print("Ik heb LEFT ingedrukt.");
            _ = new Vector3(x = (_Xspeed), y, 0);
            transform.position -= new Vector3(x, y, 0);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            print("Ik heb RIGHT ingedrukt.");
            _ = new Vector3(x = (_Xspeed), y, 0);
            transform.position += new Vector3(x, y, 0);
        }
         if (Input.GetKey(KeyCode.UpArrow))
        {
            print("Ik heb UP ingedrukt.");
            _ = new Vector3(x, y = (_Yspeed), 0);
            transform.position += new Vector3(x, y, 0);
        } 

 [SerializeField] private float _Xspeed = 0.025f;
    [SerializeField] private float _Yspeed = 0.075f;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float X = 0;
        float Y = 0;
        //float Z = -1;
        
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            print("Ik heb LeftArrow ingedrukt");
            Vector3 position = new Vector3(X = (_Xspeed), Y, 0);
            transform.position -= position;
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            print("Ik heb RightArrow ingedrukt");
            Vector3 position = new Vector3(X = (_Xspeed), Y, 0);
            transform.position += position;
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            print("Ik heb UpArrow ingedrukt");
            Vector3 position = new Vector3(X, Y = (_Yspeed), 0);
            transform.position += position;
        } */