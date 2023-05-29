using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftMovement : MonoBehaviour
{
    [SerializeField]
    float speed;
    BoxCollider2D boxCollider;
    float groundWidth;
    float obstacleWidth;
    void Start()
    {
        if (gameObject.CompareTag("Ground"))
        {
            speed = 3f;
            boxCollider = GetComponent<BoxCollider2D>();
            groundWidth = boxCollider.size.x;
        }
        else if (gameObject.CompareTag("Obstacle"))
        {
            obstacleWidth = GameObject.FindGameObjectWithTag("Tree").GetComponent<BoxCollider2D>().size.x;
        }

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector2(transform.position.x - speed * Time.deltaTime, transform.position.y);
        if (gameObject.CompareTag("Ground"))
        {
            
            if (transform.position.x <= -groundWidth)
            {
                transform.position = new Vector2(transform.position.x + 2 * groundWidth, transform.position.y);
            }

        }
        else if (gameObject.CompareTag("Obstacle"))
        {
            if (transform.position.x< GameManager.bottomleft.x-obstacleWidth)
            {
                Destroy(gameObject);
            }
        }

    }
}
