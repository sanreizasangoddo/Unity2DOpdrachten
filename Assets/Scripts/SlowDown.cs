using UnityEngine;

public class SlowDown : MonoBehaviour
{
    [SerializeField] private float _slowSpeed = 5f;

    public float GetSpeed()
    {
        return _slowSpeed;
    }
}
