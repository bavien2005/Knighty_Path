using System;
using UnityEngine;

public class MovingPlatForm : MonoBehaviour
{
    [SerializeField] private Transform posA;
    [SerializeField] private Transform posB;

    [SerializeField] private float speed = 2f;

    private Vector3 targetPosition;
    void Start()
    {
        targetPosition = posA.position;
    }

    // Update is called once per frame
    void Update()
    {

        MovingPlatform();
    }

    private void MovingPlatform()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
        {
            if (targetPosition == posA.position)
            {
                targetPosition = posB.position;
            }
            else
            {
                targetPosition = posA.position;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.transform.SetParent(transform);
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.transform.SetParent(null);
        }
    }
}
