using TMPro;
using UnityEngine;

public class PlayerCoinCollector : MonoBehaviour
{
    [SerializeField] private string _coinTag = "Coin";
    [SerializeField] private AudioClip _coinSound;
    [SerializeField] private AudioClip _rewardSound;
    [SerializeField] private TMP_Text _coinText;

    private int _coinCount = 0;
    private int _coinsNeeded = 5;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(_coinTag))
        {
            Destroy(collision.gameObject);
            _coinCount++;

            _coinText.text = "x" + _coinCount.ToString();
            AudioSource.PlayClipAtPoint(_coinSound, transform.position);

            if (_coinCount % _coinsNeeded == 0)
            {
                AudioSource.PlayClipAtPoint(_rewardSound, transform.position);
            }
        }
    }
}