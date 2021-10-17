using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slide : MonoBehaviour
{
    Rigidbody rig;
    CapsuleCollider collider;
    CharacterController controller;

    float originalHeight;
    public float reducedHeight;

    public float slideSpeed = 10f;

    bool isSliding;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        collider = GetComponent<CapsuleCollider>();
        rig = GetComponent<Rigidbody>();
        originalHeight = collider.height;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.LeftControl) && Input.GetKey(KeyCode.W))
        {
            Sliding();
        }
        else if(Input.GetKeyUp(KeyCode.LeftControl))
        {
            GoUp();
        }
    }

    private void Sliding()
    {
        controller.height = reducedHeight;
        collider.height = reducedHeight;
        rig.AddForce(transform.forward * slideSpeed, ForceMode.VelocityChange);
    }

    private void GoUp()
    {
        controller.height = originalHeight;
        collider.height = originalHeight;
    }
}
