
using System;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{

    [SerializeField] private float destroyItemCoin = 0.3f;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if ( other.CompareTag("Coin")) 
        {
            Destroy(other.gameObject, destroyItemCoin);
           // GameManager._instance.AddCoin();
            AudioManager._instance.PlayCoinSound();
        }

        else if (other.CompareTag("Trap"))
        {
            GameManager._instance.GameOver();
        }

        else if (other.CompareTag("Key"))
        {
            GameManager._instance.GameWin();
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        Collider2D collider2D = other.collider;

        if (other.gameObject.CompareTag("Enemy"))
        {
            if (collider2D is CircleCollider2D)
            {
                Destroy(other.gameObject);
            }
            else
            {
                GameManager._instance.GameOver();
            }
        }

    }
}
