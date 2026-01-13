using System;
using TMPro;
using UnityEngine;

public class PlayerInputV2 : MonoBehaviour
{
    [SerializeField] private string _coinTag = "Coin";
    [SerializeField] private string _powerup = "PowerUp";
    [SerializeField] private AudioClip _coinpickup;
    [SerializeField] private TMP_Text _coinText;
    private int _score;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
     
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(_coinTag) && collision.gameObject.CompareTag(_powerup))
        {

        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        CoinValue coinvalue;
        if (collision.gameObject.CompareTag(_coinTag) && collision.gameObject.TryGetComponent<CoinValue>(out coinvalue))
        {
            _score += coinvalue.GetScoreWorth();
            Destroy(collision.gameObject);
            print(_score);
            _coinText.text = _score.ToString();
            AudioSource.PlayClipAtPoint(_coinpickup, transform.position);
        }

        PowerUp powerUp;
        if (collision.gameObject.CompareTag(_powerup) && collision.gameObject.TryGetComponent<PowerUp>(out powerUp))
        {
            Destroy(collision.gameObject);
        }
    }
}
