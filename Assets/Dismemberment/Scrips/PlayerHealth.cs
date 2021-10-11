using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public Slider HealthBar;
    public float Health = 100;
    private float currentHealth;
    int enemyPoints= 0;
    
    void Start ()
    {
        currentHealth = Health;
    }    
    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        HealthBar.value = currentHealth;

        //Player death due to health being less than zero.

        if(currentHealth <= 0)
        {
            Destroy(this.gameObject);
            enemyPoints = enemyPoints + 50;
        }
    }

    
    // Update is called once per frame
    void Update()
    {
        
    }
}
