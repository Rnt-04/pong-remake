using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("MainScene"); // Load your game scene
    }

    public void OpenOptions()
    {
        SceneManager.LoadScene("OptionsMenu"); // Load the options menu scene
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Game Quit!"); // For testing in the editor
    }
}
