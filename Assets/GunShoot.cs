using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GunShoot : MonoBehaviour
{
    public float damage;
    public float range;
    public float fireRate;
    public int ammo;

    //public bool isFiring;
    public int Maxammo;

    
    public Text ammoDisplay;
    public Camera fpsCam;
    public ParticleSystem muzzleFlash;
    public GameObject impactEffect;
    public AudioSource gunSound;

    public Animator animator;

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
        if (Input.GetButton("Fire1") && Time.time >= nextTimeToFire && ammo > 0)
        {  
            //isFiring = true;
            animator.SetBool("isShooting", true);
            nextTimeToFire = Time.time + 1f/fireRate;
            gunSound.Play();
            Shoot();
            ammo--;
            animator.SetBool("isShooting", false);
            //isFiring = false;
        }
         if (Input.GetKey(KeyCode.R)) //&& ammo < Maxammo)
        {
            //isFiring = false;
            animator.SetFloat("isReloading", 1);
            ammo = Maxammo;
        }
        else
        {
            animator.SetFloat("isReloading", 0);
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
            
            //Die
            if (hit.transform.tag.Equals("Player")){
                Destroy(hit.collider.gameObject);
            }

            GameObject impactGO = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(impactGO, 2f);
        }  
    
    }

}
