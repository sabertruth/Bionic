using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public Slider HealthBar;
    public float Health = 100;
    private float currentHealth;
    
    void Start ()
    {
        currentHealth = Health;
    }    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        HealthBar.value = currentHealth;
    }

    
    // Update is called once per frame
    void Update()
    {
        
    }
}
