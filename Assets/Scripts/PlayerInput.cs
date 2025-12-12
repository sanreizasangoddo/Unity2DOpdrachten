using System;
using System.Drawing;
using Unity.Mathematics;
using UnityEngine;
using static UnityEditor.Searcher.SearcherWindow.Alignment;
public class PlayerInput : MonoBehaviour
{
    [SerializeField] private float speed = 8f;
    [SerializeField] private float jumpingPower = 16f;

    [SerializeField] private SpriteRenderer spriteRenderer;

    private Vector2 movement;

    private Vector2 screenBounds;

    private float playerHalfWidth;

    private float xPosLastFrame;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private Animator animator;

    private void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
        playerHalfWidth = spriteRenderer.bounds.extents.x;

        animator = GetComponent<Animator>();
    }
    void Update()
    {
        HandleMovement();
        ClampMovement();
        Flip();
    }

    private void Flip()
    {
        float input = Input.GetAxisRaw("Horizontal");
        if (input > 0 && (transform.position.x > xPosLastFrame))
        {
            spriteRenderer.flipX = false;
        } else if (input < 0 && (transform.position.x < xPosLastFrame))
        {
            spriteRenderer.flipX = true;
        }

        xPosLastFrame = transform.position.x;
    }
    private void ClampMovement()
    {
        float clampedX = Mathf.Clamp(transform.position.x, -screenBounds.x + playerHalfWidth, screenBounds.x - playerHalfWidth);
        Vector2 position = transform.position;
        position.x = clampedX;
        transform.position = position;
    }

    private void HandleMovement()
    {
        float input = Input.GetAxisRaw("Horizontal");
        movement.x = input * speed * Time.deltaTime;
        transform.Translate(movement);
        
        if (input != 0)
        {
            animator.SetBool("isRunning", true);
        } else
        {
            animator.SetBool("isRunning", false);
        }
    }
}
/*
private float horizontal;
    private float speed = 8f;
    private float jumpingPower = 16f;
    private bool isFacingRight = true;

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
        horizontal = Input.GetAxisRaw("Horizontal");

        animator.SetFloat("Speed", Mathf.Abs(horizontal));

        animator.SetBool("isGrounded", IsGrounded());

        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            animator.SetTrigger("Jump");
        }

        if (horizontal != 0)
        {
            animator.SetBool("isRunning", true);
        }

        if (Input.GetButtonDown("Jump"))
        {
            rb.linearVelocity = new Vector2(rb.linearVelocityX, jumpingPower);
            animator.SetBool("isGrounded", false);
        }
        else
        {
            animator.SetBool("isGrounded", true);
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

    public void Jump()
    {
        rb.linearVelocity = new Vector2(rb.linearVelocityX, jumpingPower);
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
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
*/