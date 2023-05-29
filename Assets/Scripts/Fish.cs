using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fish : MonoBehaviour
{
    Rigidbody2D rgb;
    [SerializeField]
    float speed;
    int angle;
    int maxAngle = 20;
    int minAngle = -60;
    public Score score;
    private void Awake()
    {
        speed = 9f;
    }
    void Start()
    {
        rgb = GetComponent<Rigidbody2D>();

        
    }
    private void FixedUpdate()
    {
        if (rgb.velocity.y > 0)
        {
            if (angle <= maxAngle)
                angle += 4;
        }
        else if (rgb.velocity.y < -2.5f)
        {
            if (angle > minAngle)
                angle -= 2;
        }
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            rgb.velocity =new Vector2(rgb.velocity.x, speed);
        }
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Obstacle"))
        {
            //Debug.Log("Scored");
            score.Scored();
        }
    }
}
