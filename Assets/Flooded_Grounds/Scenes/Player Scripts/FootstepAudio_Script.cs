using UnityEngine;
using System.Collections;

public class FootstepAudio_Script : MonoBehaviour
{

    //Initialize character movement variable
    CharacterController cc;
    void Start()
    {
        cc = GetComponent<CharacterController>();
    }

    // Update of whether foot step audio should play or not according to movement
    void Update()
    {
        if (cc.isGrounded == true && cc.velocity.magnitude > 2f && GetComponent<AudioSource>().isPlaying == false)
        {
            GetComponent<AudioSource>().Play();
        }
    }

 
}
