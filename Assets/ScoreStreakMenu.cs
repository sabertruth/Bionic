using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreStreakMenu : MonoBehaviour
{
    public GameObject inventory;

    public GameObject[] scorestreaks;

    GameObject currentWeapon;
    
    // Start is called before the first frame update
    void Start()
    {
        inventory.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Tab))
        {
            inventory.SetActive(true);
        }
        else if(Input.GetKeyUp(KeyCode.Tab))
        {
            inventory.SetActive(false);
        }
    }

    public void SelectedWeapon(int choice)
    {
        if(currentWeapon != null)
        {
            currentWeapon.SetActive(false);
        }
        currentWeapon = scorestreaks[choice];
        currentWeapon.SetActive(true);
    }
}