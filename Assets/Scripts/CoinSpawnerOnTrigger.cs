using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CoinSpawnerOnTrigger : MonoBehaviour
{
    [SerializeField] private GameObject _coinPrefab;
    [SerializeField] private Transform[] _spawnPositions;
    [SerializeField] private string _playerTag = "Player";
    [SerializeField] private AudioClip _collectedFiveCoins;

    private List<GameObject> _coins = new List<GameObject>();

    private bool _hasSpawned = false;


    private void Update()
    {
        if (_hasSpawned)
        {
            for (int i = 0; i < _coins.Count; i++)
            {
                if (!_coins[i])
                {
                    _coins.RemoveAt(i);
                }
            }
            if (_coins.Count == 0)
            {
                Destroy(gameObject);
                AudioSource.PlayClipAtPoint(_collectedFiveCoins, transform.position);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(_playerTag) && !_hasSpawned)
        {
            for (int i = 0; i < _spawnPositions.Length; i++)
            {
              _coins.Add(Instantiate(_coinPrefab, _spawnPositions[i].position, Quaternion.identity));
            }
            _hasSpawned = true;
        }
    }
}
