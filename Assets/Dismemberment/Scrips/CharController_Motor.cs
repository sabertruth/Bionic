using System.Collections;
using System.Collections.Generic;
using Mirror;
using UnityEngine;

public class CharController_Motor : NetworkBehaviour
{
    //Character controller
    public float PlayerSpeed = 10.0f;
    //public float RunSpeed = 20.0f;
    public float WalkSpeed = 10.0f;
    public float JumpHeight = 10.0f;
    public float WaterHeight = 15.5f;
    
    public float sprintMultiplier = 2;
    public bool  isSprinting = false;
    
  
    public GameObject characterBody;

    public Camera playerCamera;

    public CharacterController character;

    [Header("Components")]
    public Animator animator;

    public GameObject HUD;

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

        //Disables the camera if the player is not local
        if (!hasAuthority)
        {
            playerCamera.gameObject.SetActive(false);
            HUD.gameObject.SetActive(false);
            characterBody.tag = "Enemyplayer";
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
        //Networking using mirror-----------------
        if (!hasAuthority)
        {
            return;
        }

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

        ////Player running----------------------------------
        //if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.LeftShift))
        //{
        //    PlayerSpeed = RunSpeed;
        //}
        //else
        //{
        //    PlayerSpeed = WalkSpeed;
        //}
        //if(Input.GetKeyDown(KeyCode.W) && Input.GetKeyDown(KeyCode.LeftShift))
       // {
           // isSprinting = true;
       // }
        //else
       // {
       //     isSprinting = false;
       // }
       // if(isSprinting == true)
       // {
       //     PlayerSpeed *= sprintMultiplier;
       // }

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

        //if (Input.GetButton("Jump"))
        //{
          //   animator.SetTrigger("isJump");
        //}
        //else
        //{
        //     animator.ResetTrigger("isJump");
        //}

        if (transform.position.y < -5.0f)
        {
            Destroy(characterBody);
        }

       
    }

}
