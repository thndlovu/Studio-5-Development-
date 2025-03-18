using UnityEngine;

public class ButtonHooks : MonoBehaviour
{
    public void LoadNextScene()
    {
        SceneHandler.Instance.LoadNextScene();
    }

    public void ExitToMenu()
    {
        Time.timeScale = 1.0f;
        SceneHandler.Instance.LoadMenuScene();
    }
}
