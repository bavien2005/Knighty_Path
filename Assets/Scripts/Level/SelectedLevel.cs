using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectedLevel : MonoBehaviour
{
    [SerializeField] private int level = 1 ;

    public void OnMouseDown()
    {
        print(level);
        SceneManager.LoadScene("Game");
        SceneManager.LoadScene("EnvironmentScene", LoadSceneMode.Additive);
        SceneManager.LoadScene($"Level_{level}", LoadSceneMode.Additive);
    }
}

