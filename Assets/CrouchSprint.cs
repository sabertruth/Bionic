using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrouchSprint : MonoBehaviour
{
    //Varibles
    CharController_Motor MoveScript;
    CharacterController controller;
    CapsuleCollider playerCol;

    public float speedBoost = 8f;

    float  originalHeight;
    float  originalheight;
    public float reducedHeight;
    public Animator anim;

    // Gets the correct game components
    // Start is called before the first frame update
    void Start()
    {
        playerCol = GetComponent<CapsuleCollider>();
        MoveScript = GetComponent<CharController_Motor>();
        controller = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();

        originalHeight = playerCol.height;
        originalheight = controller.height;
    }
    
    // Waits for input from user and determines if the user wants to crouch or run

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.LeftShift))
        {
            MoveScript.WalkSpeed += speedBoost;
        }
        else if(Input.GetKeyUp(KeyCode.LeftShift))
        {
            MoveScript.WalkSpeed -= speedBoost;
        }
        if(Input.GetKeyDown(KeyCode.LeftControl))
        {
            anim.SetFloat("isCrouch", 1);
            Crouch();
        }
        else if(Input.GetKeyUp(KeyCode.LeftControl))
        {
            anim.SetFloat("isCrouch", 0);
            standUp();
        }            
    }    

    //Function to crouch by cahnging both the collider and controller height

    void Crouch()
    {
        //anim.SetFloat("isCrouch", 1);
        controller.height = reducedHeight;
        playerCol.height = reducedHeight;

    }

    //Function to return the heights to normal
    void standUp()
    {
        //anim.SetFloat("isCrouch", 0);
        playerCol.height = originalHeight;
        controller.height = originalheight;
    }
}
