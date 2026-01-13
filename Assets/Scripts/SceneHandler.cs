using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneHandler : MonoBehaviour
{
    public void RestartGame()
    {
        print("restart");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
