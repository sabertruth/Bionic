using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public Slider HealthBar;
    public float Health = 100;
    private float _currentHealth;
    
    void Start ()
    {
        _currentHealth = Health;
    }    public void TakeDamage(float damage)
    {
        _currentHealth -= damage;
        HealthBar.value = _currentHealth;
    }

    
    // Update is called once per frame
    void Update()
    {
        
    }
}
