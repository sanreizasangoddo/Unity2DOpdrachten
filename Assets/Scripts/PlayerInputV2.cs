using System;
using TMPro;
using UnityEngine;

public class PlayerInputV2 : MonoBehaviour
{
    [SerializeField] private string _coinTag = "Coin";
    [SerializeField] private AudioClip _coinSound;
    [SerializeField] private TMP_Text _coinText;
    [SerializeField] private SpriteRenderer _spriteRenderer;

    private int _score;

    private void Start()
    {
        _spriteRenderer.GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
       
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
    }
}