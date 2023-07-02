using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    int score;
    int highScore;
    Text scoreText;
    public Text panelScore;
    public Text panelHighScore;
    public GameObject newPanel;
    // Start is called before the first frame update
    void Start()
    {
        scoreText = GetComponent<Text>();
        score = 0;
        scoreText.text=score.ToString();
        panelScore.text = score.ToString();
        highScore = PlayerPrefs.GetInt("highScore");
        panelHighScore.text = highScore.ToString();
    }
    public void Scored()
    {
        score++;
        scoreText.text=score.ToString();
        panelScore.text = score.ToString();
        if (score>highScore)
        {
            highScore = score;
            panelHighScore.text=highScore.ToString();
            PlayerPrefs.SetInt("highScore",highScore);
            newPanel.SetActive(true);
        }
    }
    public int GetScore()
    {
        return score;
    }
}
