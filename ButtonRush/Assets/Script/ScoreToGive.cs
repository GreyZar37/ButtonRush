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
            scoreToAdd = Random.Range(1, 5) * 3;
        }
        
        changeMathProblem();
    }

    void Start()
    {
        
        scoreText = FindObjectOfType<ScoreText>();
        mesh = gameObject.GetComponent<MeshRenderer>();
        audioSource = gameObject.GetComponent<AudioSource>();
        particle = gameObject.GetComponent<ParticleSystem>();
    }

    void Update()
    {
        

        if(wasHit == true)
        {
            mesh.enabled = false;
            gameObject.GetComponent<Collider>().enabled = false;
            boarder.SetActive(false);
            text.SetActive(false);


            if (wasPlayed == false)
            {
                particle.Play();
                audioSource.Play();
                scoreText.addScore(scoreToAdd);
                if(wrongAnswer == false)
                {
                    gameManager.health -= 1;

                }
                wasPlayed = true;

            }
            timer -= Time.deltaTime;
            
           

            if (timer <= 0.4f)
            {
                Destroy(gameObject);
            }
 
        }
    }

    void changeMathProblem()
    {
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




            scoreToAdd = -scoreToAdd;
            answer = (numberOne * numberTwo);
            textMesh.text = numberOne.ToString() + " * " +
               numberTwo.ToString() + " = " + answer.ToString();
        }
    }
}
