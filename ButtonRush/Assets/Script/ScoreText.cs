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
        text.text = "Score: "+ score.ToString();
    }


    public void addScore(int scoreToAdd)
    {
        score += scoreToAdd;
        text.text = "Score: " + score.ToString();
    }
}
