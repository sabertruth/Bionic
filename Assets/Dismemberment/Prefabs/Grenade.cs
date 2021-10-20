using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour
{
    
    public float delay = 3f;
    public float radius = 5f;
    public float force = 600f;

    //public GameObject explosionEffect;
    public ParticleSystem explosionEffect;

    float countdown;
    bool hasExploded = false;

    void Start()
    {
        countdown = delay;
    }

    void Update()
    {
        countdown -= Time.deltaTime;
        if(countdown <= 0f)
        {
            Explode();
            hasExploded = true;
        }


    }    
    
    
    private void Explode()
    {
        explosionEffect.Play();
        //Instantiate(explosionEffect, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
