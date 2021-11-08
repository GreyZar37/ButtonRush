using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    Animator anim;
    float range = 100f;
    int layerMask = 7;

    public ParticleSystem particle;
    public TextMesh sensIndicator;
    int sensNumber = 10;

    public AudioSource audioSource;

    public Camera cam;

    void Start()
    {
        // Set the mouse sensetivity, based on the saved playerpref 
        sensNumber = PlayerPrefs.GetInt("SenseNumber", 10);
        PlayerController.mouseSens = PlayerPrefs.GetInt("Sense", 100);

        anim = gameObject.GetComponent<Animator>();
        audioSource = GameObject.Find("Player").GetComponent<AudioSource>();

        // Changes the sensetivity text based on sensetevity number
        sensIndicator.text = sensNumber.ToString() + "/10";
    }

   
    void Update()
    {
        /* A big chunk of code that shots a raycast, checks what it colided with, and then gets the different components of the gameobjects it colided with.
         * The code is used play audiosources, particlesystems and give score. It is also used to change mouse sensetivity and volume of the music. 
         */
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

                    if (hit.transform.gameObject.tag == "LowerSens")
                    {
                        hit.transform.gameObject.GetComponent<ParticleSystem>().Play();
                        hit.transform.gameObject.GetComponent<AudioSource>().Play();
                        PlayerController.mouseSens -= 10;
                        sensNumber -= 1;
                        if (PlayerController.mouseSens <= 10)
                        {
                            sensNumber = 1;
                            PlayerController.mouseSens = 10;
                        }
                        sensIndicator.text = sensNumber.ToString() + "/10";
                        PlayerPrefs.SetInt("SenseNumber", sensNumber);
                        PlayerPrefs.SetInt("Sense", PlayerController.mouseSens);
                    }
                    else if (hit.transform.gameObject.tag == "HigherSens")
                    {
                        hit.transform.gameObject.GetComponent<ParticleSystem>().Play();
                        hit.transform.gameObject.GetComponent<AudioSource>().Play();
                        PlayerController.mouseSens += 10;
                        sensNumber += 1;
                        if(PlayerController.mouseSens >= 100)
                        {
                            sensNumber = 10;
                            PlayerController.mouseSens = 100;
                        }
                        sensIndicator.text = sensNumber.ToString() + "/10";
                        PlayerPrefs.SetInt("SenseNumber", sensNumber);
                        PlayerPrefs.SetInt("Sense", PlayerController.mouseSens);
                    }
                }
               
            }
            anim.SetBool("IsShooting", true);
            particle.Play();
            audioSource.Play();
                
              
              
                
            }
        
            // Changes the player animation
        if ((anim.GetCurrentAnimatorStateInfo(0).IsName("ShootingAnim") && anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 1))
        {
            anim.SetBool("IsShooting", false);
        }
    }
    
    
}
