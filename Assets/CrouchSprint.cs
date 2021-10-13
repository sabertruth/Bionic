using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrouchSprint : MonoBehaviour
{
    CharController_Motor MoveScript;
    public float speedBoost = 8f;

    CapsuleCollider playerCol;
    float  originalHeight;
    public float reducedHeight;
    // Start is called before the first frame update
    void Start()
    {
        playerCol = GetComponent<CapsuleCollider>();
        MoveScript = GetComponent<CharController_Motor>();

        originalHeight = playerCol.height;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.LeftShift))
        {
            MoveScript.WalkSpeed += speedBoost;
        }
        else if(Input.GetKeyUp(KeyCode.LeftShift))
        {
            MoveScript.WalkSpeed -= speedBoost;
        }
        if(Input.GetKeyDown(KeyCode.LeftControl))
        {
            Crouch();
        }
        else if(Input.GetKeyUp(KeyCode.LeftControl))
        {
            standUp();
        }            
    }    

    void Crouch()
    {
        playerCol.height = reducedHeight;
    }
    void standUp()
    {
        playerCol.height = originalHeight;
    }
}
