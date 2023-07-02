using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static Vector2 bottomleft;
    public static bool gameOver;
    public GameObject gameOverPanel;
    public static bool gameStarted;
    public GameObject getReady;
    public static int gameScore;
    public GameObject score;
    // Start is called before the first frame update
    private void Awake()
    {
          bottomleft=Camera.main.ScreenToWorldPoint(new Vector2(0,0));
    }
    void Start()
    {
        gameOver=false;
        gameStarted=false;
    }
    public void GameOver()
    {
        gameOver=true;
        gameOverPanel.SetActive(true);
        score.SetActive(false);
        gameScore = score.GetComponent<Score>().GetScore();
    }
    public void GameHasStrated()
    {
        gameStarted=true;
        getReady.SetActive(false);
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
