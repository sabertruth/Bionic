using System.Collections;
using System.Collections.Generic;
using Mirror;
using UnityEngine;

public class CharController_Motor : NetworkBehaviour
{
    //Character controller
    public float PlayerSpeed = 10.0f;
    public float RunSpeed = 20.0f;
    public float WalkSpeed = 10.0f;

    public float JumpHeight = 10.0f;

    //Camera Movement
    public float MouseSensitivity = 30.0f;
    public float WaterHeight = 15.5f;

    CharacterController character;
    [Header("Components")]
    public Animator animator;

    public GameObject cam;
    // private float xRotation = 0f;

    float

            moveHorizontal,
            moveVertical;

    float

            rotX,
            rotY;

    float gravity = -9.8f;

    void Start()
    {
        character = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
        if (Application.isEditor)
        {
            MouseSensitivity = MouseSensitivity * 1.5f;
        }
    }

    void CheckForWaterHeight()
    {
        if (transform.position.y < WaterHeight)
        {
            gravity = 0f;
        }
        else
        {
            gravity = -9.8f;
        }
    }

    void Update()
    {
        //Movement Player-------------------------------------
        moveHorizontal = Input.GetAxis("Horizontal") * PlayerSpeed;
        moveVertical = Input.GetAxis("Vertical") * PlayerSpeed;

        // float mouseX = Input.GetAxis("Mouse X") * MouseSensitivity * Time.deltaTime;
        // float mouseY = Input.GetAxis("Mouse Y") * MouseSensitivity * Time.deltaTime;
        
        // xRotation -= mouseY; //---xRotation -= xRotation -mouseY;  use for code review

        // xRotation = Mathf.Clamp(xRotation, -70f, 80f);

        // //Movement Camera-------------------------------------
        // cam.transform.localRotation = Quaternion.Euler(xRotation,0,0);

        // //Rotates the player on the X axis of mouse
        // transform.rotation(0,0,0);



        CheckForWaterHeight();

        Vector3 movement = new Vector3(moveHorizontal, gravity, moveVertical);
        movement = transform.rotation * movement;
        character.Move(movement * Time.deltaTime);

			//Player Walking--------------------------------
        animator.SetFloat("vertical", moveVertical);
		animator.SetFloat("horizontal", moveHorizontal);

        	//Player running----------------------------------
        if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.LeftShift))
		{
            PlayerSpeed = RunSpeed;
        }
        else
        {
            PlayerSpeed = WalkSpeed;
        }
			// Player Crouch-------------------------------
        if (Input.GetKey(KeyCode.C))
        {
            animator.SetFloat("isCrouch", 1);
			PlayerSpeed = 0.0f;
        }
        else
        {
            animator.SetFloat("isCrouch", 0);
			PlayerSpeed = WalkSpeed;
        }
        if (Input.GetKey(KeyCode.S))
        {
            animator.SetFloat("backward", 1);
        }
    }
}
