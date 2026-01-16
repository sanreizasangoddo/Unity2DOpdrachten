using System;
using TMPro;
using UnityEngine;

public class PlayerInputV2 : MonoBehaviour
{
    [SerializeField] private string _coinTag = "Coin";
    [SerializeField] private string _powerup = "PowerUp";
    [SerializeField] private AudioClip _coinSound;
    [SerializeField] private TMP_Text _coinText;
    [SerializeField] private Rigidbody2D _rb;
    [SerializeField] private SpriteRenderer _spriteRenderer;

    private float _moveSpeed = 5f;
    private int _score;

    private void Start()
    {
        _rb.GetComponent<Rigidbody2D>();
        _spriteRenderer.GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        float moveInput = Input.GetAxisRaw("Horizontal");
        _rb.linearVelocity = new Vector2(moveInput * _moveSpeed, _rb.linearVelocityY);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        CoinValue coinvalue;
        if (collision.gameObject.CompareTag(_coinTag) &&
            collision.gameObject.TryGetComponent<CoinValue>(out coinvalue))
            {
                _score += coinvalue.GetScoreWorth();
                Destroy(collision.gameObject);

                _coinText.text = "x" + _score.ToString();
                AudioSource.PlayClipAtPoint(_coinSound, transform.position);
            }

        PowerUp powerUp;
        if (collision.gameObject.CompareTag(_powerup) &&
            collision.gameObject.TryGetComponent<PowerUp>(out powerUp))
        {
            _moveSpeed = powerUp.GetSpeed();
            Destroy(collision.gameObject);

            GetComponent<SpriteRenderer>().color = Color.yellow;
        }
    }
}