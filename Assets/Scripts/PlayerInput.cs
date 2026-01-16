using System;
using System.Drawing;
using Unity.Mathematics;
using UnityEngine;
using static UnityEditor.Searcher.SearcherWindow.Alignment;
public class PlayerInput : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 8f;
    [SerializeField] private float _jumpForce = 16f;

    private float _defaultSpeed;
    private float _xPosLastFrame;
    private float _groundCheckRadius = 0.2f;
    private bool _isGrounded;

    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private Rigidbody2D _rb;
    [SerializeField] private Transform _groundCheck;
    [SerializeField] private LayerMask _groundLayer;
    [SerializeField] private Animator _animator;
    [SerializeField] private AudioClip _jump;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _defaultSpeed = _moveSpeed;
    }
    private void Update()
    {
        float moveInput = Input.GetAxisRaw("Horizontal");
        _rb.linearVelocity = new Vector2(moveInput * _moveSpeed, _rb.linearVelocityY);

        if (Input.GetKeyDown(KeyCode.Space) && _isGrounded)
        {
            _rb.linearVelocity = new Vector2(_rb.linearVelocityX, _jumpForce);
            AudioSource.PlayClipAtPoint(_jump, transform.position);
        }

        SetAnimation(moveInput);
        Flip();
    }

    private void Flip()
    {
        float input = Input.GetAxisRaw("Horizontal");
        if (input > 0 && (transform.position.x > _xPosLastFrame))
        {
            _spriteRenderer.flipX = false;
        } else if (input < 0 && (transform.position.x < _xPosLastFrame))
        {
            _spriteRenderer.flipX = true;
        }

        _xPosLastFrame = transform.position.x;
    }

    private void FixedUpdate()
    {
        _isGrounded = Physics2D.OverlapCircle(_groundCheck.position, _groundCheckRadius, _groundLayer);
    }

    private void SetAnimation(float moveInput)
    {
        if (_isGrounded)
        {
            if (moveInput != 0)
            {
                _animator.Play("Run");
            }
            else
            {
                _animator.Play("Idle");
            }
        }
        else
        {
            if(_rb.linearVelocityY > 0)
            {
                _animator.Play("Jump");
            }
            else
            {
                _animator.Play("Fall");
            }
        }
    }

    public void SetSpeed(float newSpeed)
    {
        _moveSpeed = newSpeed;
    }

    public void ResetSpeed()
    {
        _moveSpeed = _defaultSpeed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Damage")
        {

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