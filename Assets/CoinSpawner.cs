using NUnit.Framework.Constraints;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _coinPrefab;
    [SerializeField] private GameObject _bigCoinPrefab;
    [SerializeField] private List<Transform> _coinSpawnLocations = new List<Transform>();
    [SerializeField] private List<Transform> _bigCoinSpawnLocations = new List<Transform>();

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        foreach (Transform location in _coinSpawnLocations)
        {
            Instantiate(_coinPrefab, location.position, location.rotation);
        }

        foreach (Transform location in _bigCoinSpawnLocations)
        {
            Instantiate(_bigCoinPrefab, location.position, location.rotation);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}