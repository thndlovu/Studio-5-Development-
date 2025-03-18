using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonHooks : MonoBehaviour
{
    public void LoadNextScene()
    {
        SceneHandler.Instance.LoadNextScene();
    }

    public void RestartLevel()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ExitToMenu()
    {
        Time.timeScale = 1.0f;
        SceneHandler.Instance.LoadMenuScene();
    }
}
