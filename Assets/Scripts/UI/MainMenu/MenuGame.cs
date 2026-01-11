using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuGame : MonoBehaviour
{
    public void GameStart()
    {
        SceneManager.LoadScene("Game");
        SceneManager.LoadScene("EnvironmentScene", LoadSceneMode.Additive);
        SceneManager.LoadScene("Level1", LoadSceneMode.Additive);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
