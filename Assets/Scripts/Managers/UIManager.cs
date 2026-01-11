using UnityEngine;
using UnityEngine.Events;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject panelGameWin;

    [SerializeField] private GameObject panelGameOver;

    [SerializeField] private GameObject buttonControlPlayer;

    public static UIManager Instance;

    // nên có ?? thay cho ch?c n?ng ?n hi?n ui public UnityEvent _updateUI;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void ShowGameWin()
    {
        panelGameWin.SetActive(true);
        Time.timeScale = 0;
    }

    public void UnvisibleGameWin()
    {
        Time.timeScale = 1;
        panelGameWin.SetActive(false);
    }

    public void ShowGameOver()
    {
        panelGameOver.SetActive(true);
        Time.timeScale = 0;
    }

    public void UnvisibleGameOver()
    {
        Time.timeScale = 1;
        panelGameOver.SetActive(false);
    }
    //public void ShowButtonUI()
    //{
    //    buttonControlPlayer.SetActive(true);
    //    Time.timeScale = 0;
    //}

    public void UnvisibleButtonUI()
    {
        Time.timeScale = 1;
        buttonControlPlayer.SetActive(false);
    }
}
