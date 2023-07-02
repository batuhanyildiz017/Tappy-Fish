using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Medal : MonoBehaviour
{
    public Sprite metal, bronze, silver, gold;
    Image img;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        img = GetComponent<Image>();
        int gameScore = GameManager.gameScore;
        if (gameScore>0 && gameScore<10)
        {
            img.sprite = metal;
        }else if (gameScore > 10 && gameScore < 20)
        {
            img.sprite = bronze;
        }else if (gameScore > 20 && gameScore < 30)
        {
            img.sprite = silver;
        }else if (gameScore > 30 && gameScore < 40)
        {
            img.sprite = gold;
        }
    }
}
