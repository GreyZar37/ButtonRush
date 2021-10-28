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

    public int scoreToAdd;
    float timer = 1f;

    public bool wasHit;
    public bool wasPlayed;

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


            if (wasPlayed == false)
            {
                particle.Play();
                audioSource.Play();
                scoreText.addScore(scoreToAdd);
                wasPlayed = true;

            }
            timer -= Time.deltaTime;
            
           

            if (timer <= 0.4f)
            {
                Destroy(gameObject);
            }
 
        }
    }
}
