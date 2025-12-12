using UnityEngine;

public class PowerUp : MonoBehaviour
{
    [SerializeField] private float _newSpeed;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    public float GetSpeed()
    {
        return _newSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
