using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController_Script : MonoBehaviour
{

    CharacterController MyController;

    void Start()
    {
        MyController = GetComponent<CharacterController>();
    }

}
