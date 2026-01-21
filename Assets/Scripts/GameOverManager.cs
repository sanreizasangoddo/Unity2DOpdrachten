using UnityEngine;

public class GameOverManager : MonoBehaviour
{
    [SerializeField] private GameObject _gameOverUI;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _gameOverUI.SetActive(false);
    }

    public void GameOver()
    {
        _gameOverUI.SetActive(true);
        Time.timeScale = 0f;
    }
}
