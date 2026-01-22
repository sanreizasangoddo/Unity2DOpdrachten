using NUnit.Framework.Constraints;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    [SerializeField] private string _playerTag = "Player";
    [SerializeField] private GameObject _groundPrefab;
    [SerializeField] private List<Transform> _groundSpawnLocations = new List<Transform>();
    [SerializeField] private AudioClip _spawningPlatformSound;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(_playerTag))
        {
            Destroy(gameObject);
            foreach (Transform location in _groundSpawnLocations)
            {
                Instantiate(_groundPrefab, location.position, location.rotation);
            }

            AudioSource.PlayClipAtPoint(_spawningPlatformSound, transform.position);
        }
    }
}