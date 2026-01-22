using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _jumpForce = 16f;
    [SerializeField] private int _maxHealth = 3;
    private int _currentHealth;
    private float _defaultSpeed = 5f;
    private float _deathHeight = -10f;
    private int _extraJumpsValue = 0;
    private int _extraJumps;

    private float _xPosLastFrame;
    private float _groundCheckRadius = 0.2f;
    private bool _isGrounded;

    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private string _powerUp = "PowerUp";
    [SerializeField] private string _damage = "Damage";
    [SerializeField] private Rigidbody2D _rb;
    [SerializeField] private Transform _groundCheck;
    [SerializeField] private LayerMask _groundLayer;
    [SerializeField] private Animator _animator;
    [SerializeField] private AudioClip _jump;
    [SerializeField] private AudioClip _takeDamage;
    [SerializeField] private AudioClip _powerUpSound;
    [SerializeField] private AudioClip _gameOverSound;
    [SerializeField] private Image _healthImage1;
    [SerializeField] private Image _healthImage2;
    [SerializeField] private Image _healthImage3;
    [SerializeField] private GameOverManager _gameOverManager;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _currentHealth = _maxHealth;
        _extraJumps = _extraJumpsValue;
    }
    private void Update()
    {
        float moveInput = Input.GetAxisRaw("Horizontal");
        _rb.linearVelocity = new Vector2(moveInput * _moveSpeed, _rb.linearVelocityY);

        if (_isGrounded)
        {
            _extraJumps = _extraJumpsValue;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (_isGrounded)
            {
            _rb.linearVelocity = new Vector2(_rb.linearVelocityX, _jumpForce);
            AudioSource.PlayClipAtPoint(_jump, transform.position);
            }
            else if (_extraJumps > 0)
            {
                _rb.linearVelocity = new Vector2(_rb.linearVelocityX, _jumpForce);
                _extraJumps--;
                AudioSource.PlayClipAtPoint(_jump, transform.position);
            }
        }

        SetAnimation(moveInput);
        Flip();

        if (_moveSpeed == 2)
        {
            GetComponent<SpriteRenderer>().color = Color.cyan;
        } else if (_moveSpeed == -5)
        {
            GetComponent<SpriteRenderer>().color = Color.green;
        }

        if (transform.position.y < _deathHeight)
        {
            Death();
        }
    }

    private void Flip()
    {
        float input = Input.GetAxisRaw("Horizontal");
        if (input > 0 && (transform.position.x > _xPosLastFrame))
        {
            _spriteRenderer.flipX = false;
        }
        else if (input < 0 && (transform.position.x < _xPosLastFrame))
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
            if (_rb.linearVelocityY > 0)
            {
                _animator.Play("Jump");
            }
            else
            {
                _animator.Play("Fall");
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(_damage)) 
        {
            _currentHealth -= 1;
            _rb.linearVelocity = new Vector2(_rb.linearVelocityX, _jumpForce * 1.1f);
            _moveSpeed = _defaultSpeed;
            StartCoroutine(BlinkRed());

            if (_currentHealth == 2)
            {
                _healthImage3.fillAmount = 0f;
            }
            if (_currentHealth == 1)
            {
                _healthImage2.fillAmount = 0f;
            }
            if (_currentHealth <= 0)
            {
                Death();
                _healthImage1.fillAmount = 0f;
            }
        }

        PowerUp powerUpValue;
        if (collision.gameObject.CompareTag(_powerUp) &&
            collision.gameObject.TryGetComponent<PowerUp>(out powerUpValue))
        {
            _moveSpeed = powerUpValue.GetSpeed();
            Destroy(collision.gameObject);

            AudioSource.PlayClipAtPoint(_powerUpSound, transform.position);
            GetComponent<SpriteRenderer>().color = Color.yellow;
        }
    }

    private IEnumerator BlinkRed()
    {
        _spriteRenderer.color = Color.red;
        yield return new WaitForSeconds(0.15f);
        _spriteRenderer.color = Color.white;
        AudioSource.PlayClipAtPoint(_takeDamage, transform.position);
    }

    private void Death()
    {
        _gameOverManager.GameOver();
        Destroy(gameObject);
        AudioSource.PlayClipAtPoint(_gameOverSound, transform.position);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(_powerUp))
        {
            _extraJumpsValue = 1;
            Destroy(collision.gameObject);
            AudioSource.PlayClipAtPoint(_powerUpSound, transform.position);
        }
    }
}