using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    //Movement
    private CharacterController controller;
    public float speed = 10f;

    //Camera Controller
    private float xRotation = 0f;

    public float mouseSensivity = 100f;

    public Vector3 velocity;

    //Jump And Gravity
    public float gravity = -9.8f;
    public float gravityDivide = 100f;

    private bool isGround;
    public Transform groundChecker;
    public float groundCheckerRadius;
    public LayerMask obsaluteLayer;

    public float jumpHeight;
    public float jumpSpeed = 20f;

    private float aTimer;

    private void Awake()
    {
        controller = GetComponent<CharacterController>();
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {

        //Check Character is Grounded

        isGround = Physics.CheckSphere(groundChecker.position, groundCheckerRadius, obsaluteLayer);

        //Movement
        Vector3 moveInputs = Input.GetAxis("Horizontal") * transform.right + Input.GetAxis("Vertical") * transform.forward;
        Vector3 moveVelocity = moveInputs * Time.deltaTime * speed;

        controller.Move(moveVelocity);

        //Camera Controller
        transform.Rotate(0, Input.GetAxis("Mouse X") * Time.deltaTime * mouseSensivity,0);
        xRotation -= Input.GetAxis("Mouse Y") * Time.deltaTime * mouseSensivity;

        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        Camera.main.transform.localRotation = Quaternion.Euler(xRotation,0,0);

        //Jump And Gravity
        

        if (!isGround)
        {
            velocity.y += gravity * Time.deltaTime / gravityDivide;
            aTimer += Time.deltaTime / 3;
            speed = Mathf.Lerp(10, jumpSpeed, aTimer);
        }
        else
        {
            velocity.y = -0.05f;
            speed = 10f;
            aTimer = 0;
        }

        //Jump With Space
        if(Input.GetKeyDown(KeyCode.Space) && isGround)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity / gravityDivide * Time.deltaTime);
        }
        

        controller.Move(velocity);

    }
}
