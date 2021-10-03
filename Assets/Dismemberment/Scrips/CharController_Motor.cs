using System.Collections;
using System.Collections.Generic;
using Mirror;
using UnityEngine;

public class CharController_Motor : NetworkBehaviour
{
    //Network Using Mirror------------------------------
    public Vector3 Control; //This is a sync var, mirror automatically shares and syncs this variable
                    //across all of the scripts on objects with the same network identity,
                        // but it can only be set by the server.
    public Color c;//color to change to if we are controlling this one

    //Character controller
    public float PlayerSpeed = 10.0f;
    public float RunSpeed = 20.0f;
    public float WalkSpeed = 10.0f;

    public float JumpHeight = 10.0f;
    public float WaterHeight = 15.5f;

    CharacterController character;
    [Header("Components")]
    public Animator animator;

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
        //Networking using mirror-----------------
        if (GetComponent<NetworkIdentity>().hasAuthority)//make sure this is an object that we ae controlling
        {

            //Movement Player-------------------------------------
            moveHorizontal = Input.GetAxis("Horizontal") * PlayerSpeed;
            moveVertical = Input.GetAxis("Vertical") * PlayerSpeed;


            CheckForWaterHeight();

            Vector3 movement = new Vector3(moveHorizontal, gravity, moveVertical);
            movement = transform.rotation * movement;
            character.Move(movement * Time.deltaTime);

                //Player Walking--------------------------------
            animator.SetFloat("vertical", moveVertical);
            animator.SetFloat("horizontal", moveHorizontal);

            Vector3 idle = new Vector3(0,0,0);
            if(movement != idle)
            {
                animator.SetBool("isIdle", false);
            }
            else
            {
                animator.SetBool("isIdle", true);
            }


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

            if (Input.GetButton("Fire2"))
            {
                animator.SetBool("isADSWeapon", true);
            }
            else
            {
                animator.SetBool("isADSWeapon", false);
            }

            // if (Input.GetButton("Jump"))
            // {
            //     animator.SetTrigger("isJump");
            // }
            // else
            // {
            //     animator.ResetTrigger("isJump");
            // }
        }
    }
}
