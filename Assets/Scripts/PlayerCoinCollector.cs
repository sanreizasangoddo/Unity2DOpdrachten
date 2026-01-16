using TMPro;
using UnityEngine;

public class PlayerCoinCollector : MonoBehaviour
{
    [SerializeField] private string coinTag = "Coin";
    [SerializeField] private AudioClip coinPickup;
    [SerializeField] private AudioClip rewardSound;
    [SerializeField] private TMP_Text coinText;

    private int coinCount = 0;
    private int coinsNeeded = 5;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(coinTag))
        {
            Destroy(collision.gameObject);
            coinCount++;

            coinText.text = coinCount.ToString();
            AudioSource.PlayClipAtPoint(coinPickup, transform.position);

            if (coinCount == coinsNeeded)
            {
                AudioSource.PlayClipAtPoint(rewardSound, transform.position);
            }
        }
    }
}