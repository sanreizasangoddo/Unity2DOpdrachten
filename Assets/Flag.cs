using UnityEngine;

public class Flag : MonoBehaviour
{
    [SerializeField] private GameObject _winUI;
    [SerializeField] private string _playerTag = "Player";
    [SerializeField] private AudioClip _winSound;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(_playerTag))
        {
            Time.timeScale = 0;
            _winUI.SetActive(true);
            AudioSource.PlayClipAtPoint(_winSound, transform.position);
        }
    }
}
