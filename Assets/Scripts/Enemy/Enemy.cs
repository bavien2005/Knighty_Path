using UnityEngine;

public class Enemy : MonoBehaviour
{

    [SerializeField] private float speed = 2f;

    [SerializeField] private float distance = 2f;

    private Vector3 startPosition;

    private bool movingRight = true;
    void Start()
    {
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {


        EnemyMoving();


    }

    private void EnemyMoving()
    {
        float rightBound = startPosition.x + distance;

        float leftBound = startPosition.x - distance;

        if (movingRight)
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);

            if (transform.position.x >= rightBound)
            {
                movingRight = false;
                flip();
            }
        }

        else
        {
            transform.Translate(Vector2.left * speed * Time.deltaTime);
            if (transform.position.x <= leftBound)
            {
                movingRight = true;
                flip();
            }
        }
    }


    private void flip()
    {
        if (movingRight) transform.localScale = new Vector3(1, 1, 1);

        else transform.localScale = new Vector3(-1, 1, 1);
    }
}
