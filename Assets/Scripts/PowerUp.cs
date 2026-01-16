using UnityEngine;
using System.Collections;

public class PowerUp : MonoBehaviour
{
    [SerializeField] private float _newSpeed = 8f;

    public float GetSpeed()
    {
        return _newSpeed;
    }
}