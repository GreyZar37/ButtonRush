using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public Transform playerCamera;
    public Transform groundCheck;

    public GameObject gunAndArm;

    public LayerMask groundMask;
    public Rigidbody rb;

    public float speed = 1f;
    public float mouseSens = 100f;

    public float groundDistance = 0.3f;
    public float jumpHeight;

    float vertical, mouseVertical;
    float horizontal, mouseHorizontal;
    float xRotation = 0f;

    bool jumped;

    bool isGrounded;


    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Physics.gravity = new Vector3(0, -24.82F, 0);
    }
    private void Update()
    {
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            jumped = true;
        }

      
    }

    private void FixedUpdate()
    {
        movement();
    }

    public void movement()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        //Kodedelen hvor spilleren f�r lov til at rotere sit camera (Rotation)
        mouseHorizontal = Input.GetAxis("Mouse X") * mouseSens * Time.deltaTime;
        mouseVertical = Input.GetAxis("Mouse Y") * mouseSens * Time.deltaTime;

        xRotation -= mouseVertical;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        playerCamera.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        gunAndArm.GetComponent<Transform>().localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        transform.Rotate(Vector3.up * mouseHorizontal);



        //Kodedelen hvor spilleren f�r lov til at g� (Movement)
        vertical = Input.GetAxisRaw("Vertical");
        horizontal = Input.GetAxisRaw("Horizontal");
        

        rb.AddForce(transform.right * horizontal * speed);
        rb.AddForce(transform.forward * vertical * speed);

        
      

        if ( jumped)
        {
            jumped = false;
            rb.AddForce(Vector3.up * jumpHeight, ForceMode.Impulse);
        }
       

    }
}