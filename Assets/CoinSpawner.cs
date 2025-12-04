using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _coin;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Instantiate(_coin, transform.position, transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
