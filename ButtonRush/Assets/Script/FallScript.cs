using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallScript : MonoBehaviour
{
    Rigidbody rb;
    public float gravity;
    
    // Start is called before the first frame update
    void Start()
    {
        if(gameManager.difficulty == "Hard")
        {
            gravity = -2;
        }
        else
        {
            gravity = -1;
        }
        rb = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector3(0, gravity, 0);
    }
}
