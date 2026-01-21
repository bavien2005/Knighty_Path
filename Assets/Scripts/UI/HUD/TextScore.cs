using TMPro;
using UnityEngine;

[RequireComponent(typeof(TMPro.TextMeshProUGUI))]
public class TextScore : MonoBehaviour
{

    private TextMeshProUGUI m_TextMeshPro;

    private void Awake()
    {
        m_TextMeshPro = GetComponent<TextMeshProUGUI>();
    }


    private void Start()
    {
        // GameManager._instance._updateScore.AddListener(UpdateScoreText);
    }


    private void UpdateScoreText(int coin)
    {
        m_TextMeshPro.text = "Score: " + coin.ToString();
    }
    private void OnEnable()
    {
        if (GameManager._instance != null)
        {
            GameManager._instance._updateScore.AddListener(UpdateScoreText);
        }
    }

    private void OnDisable()
    {
        if (GameManager._instance != null)
        {
            GameManager._instance._updateScore.RemoveListener(UpdateScoreText);
        }
    }
}
