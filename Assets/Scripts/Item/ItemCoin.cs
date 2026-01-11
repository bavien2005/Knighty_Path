using UnityEngine;

public class ItemCoin : MonoBehaviour
{

    [SerializeField] private int coinValue = 1;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GameManager._instance.AddCoin(coinValue);
            AudioManager._instance.PlayCoinSound();
            Destroy(gameObject);
        }
    }
}
