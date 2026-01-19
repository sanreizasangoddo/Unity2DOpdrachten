using UnityEngine;
using System.Collections;

public class PowerUp : MonoBehaviour
{
    [SerializeField] private float _newSpeed;

    public float GetSpeed()
    {
        return _newSpeed;
    }
}