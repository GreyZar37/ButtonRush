using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class gameManager : MonoBehaviour
{
    public static int health;
    public static string difficulty = "Easy";

    public static bool gameStarted;

    public GameObject[] tavler;

    public TextMeshProUGUI livesText;
    public TextMeshProUGUI difficultyText;




    public TextMesh highScore, currentScore, levelNedded, grade;
    public int grade_, highScore_, levelNedded_;
    public static int currentScore_;
    public bool scoreSet;
    public static int xp;

    void Start()
    {
       // Gets the data from playerprefs to the variables at the start
       xp = PlayerPrefs.GetInt("Xp", 0);
       grade_ = PlayerPrefs.GetInt("Grade", -3);
       levelNedded_ = PlayerPrefs.GetInt("LevelNedded", 50);
       highScore_ = PlayerPrefs.GetInt("HighScore", 0);


       difficultyText.text = "Difficulty: " + difficulty;
       
    }

    void Update()
    {
        // Saves the data to playerprefs
        PlayerPrefs.SetInt("Xp", xp);
        PlayerPrefs.SetInt("Grade", grade_);
        PlayerPrefs.SetInt("LevelNedded", levelNedded_);
        PlayerPrefs.SetInt("HighScore", highScore_);


        tavleScoreTracker();

        // Changes the live text
        switch (health)
        {
            case 3:
                livesText.text = "Lives: III";
                break;
            case 2:
                livesText.text = "Lives: II";
                break;
            case 1:
                livesText.text = "Lives: I";
                break;
            case 0:
                livesText.text = "Lives: ";
                resetGame();
                break;

            default:
                break;
        }


        tavler = GameObject.FindGameObjectsWithTag("Tavle");

       
    }

    public void resetGame()
    {
        // Reset the game, and score

        ScoreText.score = 0;
        scoreSet = false;
        GameObject.FindObjectOfType<ScoreText>().text.text = "Score: " + ScoreText.score.ToString();

        if (difficulty == "Hard")
        {
            health = 1;

        }
        else
        {
            health = 3;
        }
      
        gameStarted = false;

        // Destroy all "Tavler" in the game
        for (int i = 0; i < tavler.Length; i++)
        {
            Destroy(tavler[i]);
        }
    }
    public void changeDifficulty()
    {
        // Changes the difficulty of the game
        difficultyText.text = "Difficulty: " + difficulty;
        if (difficulty == "Hard")
        {
            health = 1;

        }
        else
        {
            health = 3;
        }
    }

    void tavleScoreTracker()
    {
       // Changes level nedded, highscore and xp

        switch (grade_)
        {
            case -3:
                levelNedded_ = 50;
                break;
            case 00:
                levelNedded_ = 75;
                break;
            case 02:
                levelNedded_ = 150;
                break;
            case 4:
                levelNedded_ = 250;
                break;
            case 7:
                levelNedded_ = 500;
                break;
            case 10:
                levelNedded_ = 750;
                break;
            case 12:
                levelNedded_ = 1000;
                break;
            case 13:
                levelNedded_ = 1000;
                xp = 1000;
                break;

            default:
                break;
        }

        if(xp >= levelNedded_)
        {
            switch (grade_)
            {
                case -3:
                    grade_ = 00;
                    xp = 0;
                    break;
                case 00:
                    grade_ = 02;
                    xp = 0;

                    break;
                case 02:
                    grade_ = 4;
                    xp = 0;

                    break;
                case 4:
                    grade_ = 7;
                    xp = 0;

                    break;
                case 7:
                    grade_ = 10;
                    xp = 0;

                    break;
                case 10:
                    grade_ = 12;
                    xp = 0;

                    break;
                case 12:
                    grade_ = 13;


                    break;

            }
        }
        
        if(xp < 0)
        {
            xp = 0;
        }
        if(currentScore_ > highScore_)
        {
            highScore_ = currentScore_;
        }

        // Changes the text on the main "Tavle"
        grade.text = "Your grade: " + grade_.ToString();
        levelNedded.text = "Next grade: " + xp + "/" + levelNedded_.ToString();
        currentScore.text = "Last score: " + currentScore_.ToString();
        highScore.text = "High score: " + highScore_.ToString();
    }
}
