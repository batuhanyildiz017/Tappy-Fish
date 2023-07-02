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
    bool touchedGround;
    public GameManager gameManager;
    public Sprite fishDied;
    SpriteRenderer sp;
    Animator anim;
    public ObstacleSpawner obsSpawn;
    [SerializeField]AudioSource swim,hit,point;
    private void Awake()
    {
        speed = 9f;
    }
    void Start()
    {
        rgb = GetComponent<Rigidbody2D>();
        rgb.gravityScale = 0;
        sp = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }
    private void FixedUpdate()
    {
        FishRotation();
    }

    // Update is called once per frame
    void Update()
    {
        FishSwim();
        
    }
    void FishSwim()
    {
        //rgb.velocity=Vector2.zero;
        if (Input.GetMouseButtonDown(0) && GameManager.gameOver==false)
        {
            swim.Play();
            if (GameManager.gameStarted == false)
            {
                rgb.gravityScale = 1.3f;
                rgb.velocity = Vector2.zero;
                rgb.velocity = new Vector2(rgb.velocity.x, speed);
                obsSpawn.InstantiateObstacle();
                gameManager.GameHasStrated();
            }
            else
            {
                rgb.velocity = Vector2.zero;
                rgb.velocity = new Vector2(rgb.velocity.x, speed);
            }
                
        }
    }
    void FishRotation()
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
        if(touchedGround==false)
            transform.rotation = Quaternion.Euler(0, 0, angle);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Obstacle"))
        {
            //Debug.Log("Scored");
            score.Scored();
            point.Play();
        }
        else if (collision.CompareTag("Tree"))
        {
            FishDieEffect();
            //game over
            gameManager.GameOver();
            GameOver();
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            if (GameManager.gameOver==false)
            {
                FishDieEffect();
                //game over
                gameManager.GameOver();
                GameOver();
            }

        }
    }
    public void FishDieEffect()
    {
        hit.Play();
    }
    void GameOver()
    {
        touchedGround = true;
        sp.sprite = fishDied;
        anim.enabled = false;
        transform.rotation=Quaternion.Euler(0, 0, -90);
    }
}
