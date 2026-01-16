using UnityEngine;

public enum PowerUpType
{
    SpeedUp,
    SlowDown
}

public class PowerUp : MonoBehaviour
{
    [SerializeField] private float _newSpeed = 10f;

    [SerializeField] private PowerUpType powerUpType;
    [SerializeField] private float speedValue = 8f;
    [SerializeField] private float duration = 3f;

    public PowerUpType Type => powerUpType;
    public float SpeedValue => speedValue;
    public float Duration => duration;

    public float GetSpeed()
    {
        GetComponent<SpriteRenderer>().color = Color.yellow;
        return _newSpeed;
    }
}