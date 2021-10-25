using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
  
    public CharacterController characterController;

    public Transform playerCamera;
    public Transform groundCheck;

    public GameObject gunAndArm;
    
    public LayerMask groundMask;


    public float speed = 1f;
    public float mouseSens = 100f;

    public float gravity = -9.82f;
    public float groundDistance = 0.3f;
    public float jumpHeight;

    float vertical, mouseVertical;
    float horizontal, mouseHorizontal;
    float xRotation = 0f;
    
    Vector3 move;
    Vector3 velocity;
   
    bool isGrounded;


    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void FixedUpdate()
    {
        movement();
    }

    public void movement()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        //Kodedelen hvor spilleren får lov til at rotere sit camera (Rotation)
        mouseHorizontal = Input.GetAxis("Mouse X") * mouseSens * Time.deltaTime;
        mouseVertical = Input.GetAxis("Mouse Y") * mouseSens * Time.deltaTime;

        xRotation -= mouseVertical;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        playerCamera.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        gunAndArm.GetComponent<Transform>().localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        transform.Rotate(Vector3.up * mouseHorizontal);

        

        //Kodedelen hvor spilleren får lov til at gå (Movement)
        vertical = Input.GetAxis("Vertical");
        horizontal = Input.GetAxis("Horizontal");

        move = transform.right * horizontal + transform.forward * vertical;

        characterController.Move(move * speed * Time.deltaTime);

        velocity.y += gravity * Time.deltaTime;
        characterController.Move(velocity * Time.deltaTime);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        if (Input.GetButton("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            print("jump");
        }

    
    }
}
