using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftMovement : MonoBehaviour
{
    [SerializeField]
    float speed;
    BoxCollider2D boxCollider;
    float groundWidth;
    void Start()
    {
        speed = 3f;
        boxCollider = GetComponent<BoxCollider2D>();
        groundWidth = boxCollider.size.x;
    }

    // Update is called once per frame
    void Update()
    {
        
        transform.position = new Vector2(transform.position.x - speed*Time.deltaTime, transform.position.y);
        if (transform.position.x<=-groundWidth)
        {
            transform.position = new Vector2(transform.position.x+2*groundWidth,transform.position.y);
        }
    }
}
