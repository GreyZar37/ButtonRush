using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    Animator anim;
    float range = 100f;

    public ParticleSystem particle;

    public Camera cam;

    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
    }

   
    void Update()
    {
        
            if (Input.GetMouseButtonDown(0))
            {
                RaycastHit hit;
                if(Physics.Raycast(cam.transform.position,cam.transform.forward, out hit, range))
                {
                    hit.transform.GetComponent<MeshRenderer>().material.color = Color.green;
                }

                anim.SetBool("IsShooting", true);
                particle.Play();
              
                
            }
        
        if ((anim.GetCurrentAnimatorStateInfo(0).IsName("ShootingAnim") && anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 1))
        {
            anim.SetBool("IsShooting", false);
        }
    }

    
}
