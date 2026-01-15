using UnityEngine;
using UnityEngine.SceneManagement;
public class StartButton : MonoBehaviour
{

    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public void onClickStartButton()
    {
        SceneManager.LoadScene("GameMap");

    }
    public void onClickTitleButton()
    {
        SceneManager.LoadScene(" ");
    }
    public void onClickDesktopButton()
    {
        Application.Quit();

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }

}
