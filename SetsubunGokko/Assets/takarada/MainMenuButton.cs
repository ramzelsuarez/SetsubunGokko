using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenuButton : MonoBehaviour
{
    // Start button
    public void StartGame()
    {
        SceneManager.LoadScene("GameMap");
    }
    // Quit button
    public void QuitGame()
    {
        Application.Quit();
        // For testing in the Unity Editor
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}
