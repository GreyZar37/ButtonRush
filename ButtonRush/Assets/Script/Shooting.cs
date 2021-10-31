using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    Animator anim;
    float range = 100f;
    int layerMask = 7;

    public ParticleSystem particle;

    public AudioSource audioSource;

    public Camera cam;

    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        audioSource = GameObject.Find("Player").GetComponent<AudioSource>();
    }

   
    void Update()
    {
        
            if (Input.GetMouseButtonDown(0))
            {
                RaycastHit hit;
                if(Physics.Raycast(cam.transform.position,cam.transform.forward, out hit, range, layerMask))
                {
                
                if(hit.transform.gameObject.GetComponent<ScoreToGive>() != null)
                {
                    hit.transform.gameObject.GetComponent<ScoreToGive>().wasHit = true;
                }

                if (hit.transform.gameObject.tag == "StartGameStation")
                {
                   gameManager.currentScore_ = 0;
                    hit.transform.gameObject.GetComponent<ParticleSystem>().Play();
                    hit.transform.gameObject.GetComponent<AudioSource>().Play();

                    gameManager.gameStarted = true;
                }
                else if(hit.transform.gameObject.tag == "StopGameStation")
                {
                    hit.transform.gameObject.GetComponent<ParticleSystem>().Play();
                    hit.transform.gameObject.GetComponent<AudioSource>().Play();

                    FindObjectOfType<gameManager>().resetGame();                    
                }

                if(gameManager.gameStarted == false)
                {
                    if (hit.transform.gameObject.tag == "Easy")
                    {
                        hit.transform.gameObject.GetComponent<ParticleSystem>().Play();
                        hit.transform.gameObject.GetComponent<AudioSource>().Play();

                        gameManager.difficulty = "Easy";
                        FindObjectOfType<gameManager>().changeDifficulty();

                    }

                    else if (hit.transform.gameObject.tag == "Medium")
                    {
                        hit.transform.gameObject.GetComponent<ParticleSystem>().Play();
                        hit.transform.gameObject.GetComponent<AudioSource>().Play();

                        gameManager.difficulty = "Medium";
                        FindObjectOfType<gameManager>().changeDifficulty();


                    }
                    else if (hit.transform.gameObject.tag == "Hard")
                    {
                        hit.transform.gameObject.GetComponent<ParticleSystem>().Play();
                        hit.transform.gameObject.GetComponent<AudioSource>().Play();
                        gameManager.difficulty = "Hard";
                        FindObjectOfType<gameManager>().changeDifficulty();
                    }

                    if (hit.transform.gameObject.tag == "LowerVolume")
                    {
                        hit.transform.gameObject.GetComponent<ParticleSystem>().Play();
                        hit.transform.gameObject.GetComponent<AudioSource>().Play();
                        Volume.volume -= 0.1f;
                        if(Volume.volume <= 0)
                        {
                            Volume.volume = 0;
                        }
                    }
                    else if (hit.transform.gameObject.tag == "HigherVolume")
                    {
                        hit.transform.gameObject.GetComponent<ParticleSystem>().Play();
                        hit.transform.gameObject.GetComponent<AudioSource>().Play();
                        Volume.volume += 0.1f;
                        if (Volume.volume >= 1)
                        {
                            Volume.volume = 1;
                        }
                    }
                }
               
            }
            anim.SetBool("IsShooting", true);
            particle.Play();
            audioSource.Play();
                
              
              
                
            }
        
        if ((anim.GetCurrentAnimatorStateInfo(0).IsName("ShootingAnim") && anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 1))
        {
            anim.SetBool("IsShooting", false);
        }
    }
    
    
}
