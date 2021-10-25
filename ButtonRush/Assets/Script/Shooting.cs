using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    Animator anim;
    float cooldown;
    float range = 100f;

    public ParticleSystem particle;

    public Camera cam;

    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
    }

   
    void Update()
    {
        cooldown -= Time.deltaTime;
        if(cooldown <= 0)
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
                cooldown += 0.25f;
                
            }
           
        }    
    }

    public void shooting()
    {
        anim.SetBool("IsShooting", false);

    }
}
