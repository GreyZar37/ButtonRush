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
                hit.transform.gameObject.GetComponent<ScoreToGive>().wasHit = true;
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
