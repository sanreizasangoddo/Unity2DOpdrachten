using UnityEngine;

public class CoinValue : MonoBehaviour
{
    [SerializeField] private int _scoreWorth;

    public int GetScoreWorth()
    {
        return _scoreWorth;
    }
}