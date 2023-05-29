using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    int score;
    Text scoreText;
    // Start is called before the first frame update
    void Start()
    {
        scoreText = GetComponent<Text>();
        score = 0;
        scoreText.text=score.ToString();
    }
    public void Scored()
    {
        score++;
        scoreText.text=score.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
