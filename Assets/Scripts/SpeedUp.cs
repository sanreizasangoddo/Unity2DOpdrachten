using UnityEngine;

public class SpeedUp : MonoBehaviour
{
    [SerializeField] private float _speedIncrease = 12f;

    public float GetSpeed()
    {
        return _speedIncrease;
    }
}
