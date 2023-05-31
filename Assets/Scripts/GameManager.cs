using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static Vector2 bottomleft;
    public static bool gameOver;
    public GameObject gameOverPanel;
    // Start is called before the first frame update
    private void Awake()
    {
          bottomleft=Camera.main.ScreenToWorldPoint(new Vector2(0,0));
    }
    void Start()
    {
        gameOver=false;
    }
    public void GameOver()
    {
        gameOver=true;
        gameOverPanel.SetActive(true);
    }
    public void RestartButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
