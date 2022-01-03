using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreText : MonoBehaviour
{

    public static int score = 0;
    public TextMeshProUGUI text;


    void Start()
    {
        // Changes the score text in the UI in the start
        text.text = "Score: "+ score.ToString();
    }


    public void addScore(int scoreToAdd)
    {
        // Add score to the score variable 
        score += scoreToAdd;
        // Adds score to xp and current score
        gameManager.currentScore_ += scoreToAdd;
        gameManager.xp += scoreToAdd;
        // Changes the score text in the UI
        text.text = "Score: " + score.ToString();
    }
}
