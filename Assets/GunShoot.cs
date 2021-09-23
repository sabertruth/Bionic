using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GunShoot : MonoBehaviour
{
    public float damage = 25f;
    public float range = 100f;
    public float fireRate = 15f;
    public int ammo;
    public bool isFiring;
    
    public Text ammoDisplay;
    public Camera fpsCam;
    public ParticleSystem muzzleFlash;
    public GameObject impactEffect;
    public AudioSource gunSound;    
    
    private float nextTimeToFire = 0f;
    

    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start()
    {
        gunSound = GetComponent<AudioSource>();
    }
    
    // Update is called once per frame
    void Update()
    {
        ammoDisplay.text = ammo.ToString();
        if (Input.GetButton("Fire1") && Time.time >= nextTimeToFire && !isFiring && ammo > 0)
        {   
            isFiring = true;
            nextTimeToFire = Time.time + 1f/fireRate;
            gunSound.Play();
            Shoot();
            ammo--;
            isFiring = false;
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            ammo = 25;
        }
    }

    
    void Shoot()
    {
        muzzleFlash.Play();

        RaycastHit hit;
        if(Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);

            Target target = hit.transform.GetComponent<Target>();
            if(target != null)
            {
                target.TakeDamage(damage);
            }

            GameObject impactGO = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(impactGO, 2f);
        }  
    
    }

}
