using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour
{
    public float delay = 3f;
    public float radius = 5f;
    public float force = 600f;

    public ParticleSystem explosionEffect;

    float countdown;

    void Start()
    {
        countdown = delay;
    }

    void Update()
    {
        countdown -= Time.deltaTime;
        if (countdown <= 0f)
        {
            StartCoroutine(Explode());
        }
    }

    IEnumerator Explode()
    {
        explosionEffect.Play();
        yield return new WaitForSeconds(2f);
        Destroy (gameObject);
    }

}
