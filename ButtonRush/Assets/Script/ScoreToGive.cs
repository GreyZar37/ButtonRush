using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreToGive : MonoBehaviour
{

    ScoreText scoreText;

    MeshRenderer mesh;
    AudioSource audioSource;
    ParticleSystem particle;

    public GameObject boarder;
    public GameObject text;

    public TextMesh textMesh;

    int numberOne;
    int numberTwo;
    int answer;
    int addOrSubt;

    public int scoreToAdd;
    float timer = 1f;

    public bool wasHit;
    public bool wasPlayed;

    public bool wrongAnswer;


    private void Awake()
    {
        // The score is random and gets multiplied by difficulty
        if(gameManager.difficulty == "Easy")
        {
            scoreToAdd = Random.Range(1, 5) * 1;
        }
        else if (gameManager.difficulty == "Medium")
        {
            scoreToAdd = Random.Range(1, 5) * 2;
        }
        else if (gameManager.difficulty == "Hard")
        {
            scoreToAdd = Random.Range(2, 5) * 3;
        }
        
        changeMathProblem();
    }

    void Start()
    {
        // Get component from the gameobject 
        scoreText = FindObjectOfType<ScoreText>();
        mesh = gameObject.GetComponent<MeshRenderer>();
        audioSource = gameObject.GetComponent<AudioSource>();
        particle = gameObject.GetComponent<ParticleSystem>();
    }

    void Update()
    {
        

        if(wasHit == true)
        {
            // Disables the meshrenderer, collider, boarder and text
            mesh.enabled = false;
            gameObject.GetComponent<Collider>().enabled = false;
            boarder.SetActive(false);
            text.SetActive(false);


            if (wasPlayed == false)
            {
                // Enables the particle, audio, and adds score
                particle.Play();
                audioSource.Play();
                scoreText.addScore(scoreToAdd);

                // If the ansewer was wrong, then you lose health
                if(wrongAnswer == false)
                {
                    gameManager.health -= 1;

                }
                wasPlayed = true;

            }
           
            // After 0.4 seconds, destroy the gameobjet
            timer -= Time.deltaTime;
 
            if (timer <= 0.4f)
            {
                Destroy(gameObject);
            }
 
        }
    }

    void changeMathProblem()
    {
        // Changes the mathproblem
        if(wrongAnswer == true)
        {
            if(gameManager.difficulty == "Easy")
            {
                numberOne = Random.Range(0, 11);
                numberTwo = Random.Range(0, 11);
            }
            else if (gameManager.difficulty == "Medium")
            {
                numberOne = Random.Range(10, 100);
                numberTwo = Random.Range(0, 11);
            }
            else if (gameManager.difficulty == "Hard")
            {
                numberOne = Random.Range(0, 100);
                numberTwo = Random.Range(0, 11);
            }

            addOrSubt = Random.Range(1, 3);


            if (addOrSubt == 1)
            {
                answer = (numberOne * numberTwo) - Random.Range(1, 6);
            }
            else if (addOrSubt == 2)
            {
                answer = (numberOne * numberTwo) + Random.Range(1, 6);
            }

            //Change the text to the mathproblem on the "Tavle"

            textMesh.text = numberOne.ToString() + " * " + 
                numberTwo.ToString() + " = " + answer.ToString();
        }
        else if(wrongAnswer == false)
        {

            if (gameManager.difficulty == "Easy")
            {
                numberOne = Random.Range(0, 11);
                numberTwo = Random.Range(0, 11);
            }
            else if (gameManager.difficulty == "Medium")
            {
                numberOne = Random.Range(10, 100);
                numberTwo = Random.Range(0, 11);
            }
            else if (gameManager.difficulty == "Hard")
            {
                numberOne = Random.Range(0, 100);
                numberTwo = Random.Range(0, 11);
            }



            //Makes score negative and changes the text to the mathproblem on the "Tavle"
            scoreToAdd = -scoreToAdd;
            answer = (numberOne * numberTwo);
            textMesh.text = numberOne.ToString() + " * " +
               numberTwo.ToString() + " = " + answer.ToString();
        }
    }
}
