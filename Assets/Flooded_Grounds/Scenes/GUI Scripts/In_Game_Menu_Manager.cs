using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class In_Game_Menu_Manager : MonoBehaviour
{

    public GameObject WeaponStoreUI;

    void Update()
    {
        if (Input.GetButtonDown("1Key"));
        {
            WeaponStoreUI.SetActive(true);
        }
    }



}
