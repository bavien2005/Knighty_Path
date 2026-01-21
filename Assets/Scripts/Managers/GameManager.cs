using System;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private int scoreCoin = 0;


    public UnityEvent<int> _updateScore; 

    public static GameManager _instance;

    private GameData data;

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        data = SaveSystem.Load();
        scoreCoin = data.coin;
        _updateScore?.Invoke(scoreCoin);
    }

    public void AddCoin(int coin)
    {
        //this.scoreCoin += coin;
        //_updateScore?.Invoke(scoreCoin);
        this.scoreCoin += coin;
        _updateScore?.Invoke(scoreCoin);
        data.coin = scoreCoin;
        SaveSystem.Save(data);
    }

    public void GameOver()
    {
        UIManager.Instance.ShowGameOver();
        Time.timeScale = 0;
    }

    public void RestarGame()
    {
        UIManager.Instance.UnvisibleGameOver();
        SceneManager.LoadScene("Game");
        SceneManager.LoadScene("EnvironmentScene", LoadSceneMode.Additive);
        SceneManager.LoadScene("Level_1", LoadSceneMode.Additive);
        Time.timeScale = 1;
    }

    public void GameWin()
    {
       UIManager.Instance.ShowGameWin();
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1;
        AudioManager._instance.StopAllSounds();
        UIManager.Instance.UnvisibleGameWin();
        UIManager.Instance.UnvisibleGameOver();
        UIManager.Instance.UnvisibleButtonUI();
    }
}
