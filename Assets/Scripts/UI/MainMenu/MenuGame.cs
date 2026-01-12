using System.ComponentModel;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuGame : MonoBehaviour
{
    [Header("PANEL UI")]
    [SerializeField] private GameObject panelMainMenu;
    [SerializeField] private GameObject panelMapSelect;

    [SerializeField] private int numberLevel = 1;

    private void Start()
    {
        panelMapSelect.SetActive(false);
    }
    public void GameStart()
    {
        //SceneManager.LoadScene("Game");
        //SceneManager.LoadScene("EnvironmentScene", LoadSceneMode.Additive);
        //SceneManager.LoadScene("Level1", LoadSceneMode.Additive);
        panelMainMenu.SetActive(false);
        panelMapSelect.SetActive(true);
        CursorManager._instance.SetHandCursor();
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void Level()
    {
        if (numberLevel == 1)
        {
            SceneManager.LoadScene("Game");
            SceneManager.LoadScene("EnvironmentScene", LoadSceneMode.Additive);
            SceneManager.LoadScene("Level1", LoadSceneMode.Additive);
        }
    }
}
