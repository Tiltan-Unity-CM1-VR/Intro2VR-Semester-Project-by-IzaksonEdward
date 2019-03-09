using UnityEngine;
using UnityEngine.SceneManagement;
public class ChangeScenes : MonoBehaviour
{
    public void LoadMainScene()
    {
        SceneManager.LoadScene("Main");
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("YOUVE QUIT THE GAME!!!");
    }
}
