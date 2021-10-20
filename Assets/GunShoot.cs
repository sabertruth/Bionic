using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GunShoot : MonoBehaviour
{
    //Public Static Variable For score, accessed by Scoreboard Script
    public int score = 10;
    private ScoreBoard scoreBoard;

    void Awake()
    {
        scoreBoard = GameObject.FindObjectOfType<ScoreBoard> ();
    }

    public float damage;
    public float range;
    public float fireRate;
    public int ammo;

    public Slider HealthBar;
    public float Health = 100;
    private float currentHealth;

    //public bool isFiring;
    public int Maxammo;

    public Text ammoDisplay;
    public Camera fpsCam;
    public ParticleSystem muzzleFlash;
    public GameObject impactEffect;
    public AudioSource gunSound;
    public GameObject hitmarker;

    public Animator animator;

    private float nextTimeToFire = 0f;

    void Start()
    {
        hitmarker.SetActive(false);
        gunSound = GetComponent<AudioSource>();
        currentHealth = Health;
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
            
            //Target target = hit.transform.GetComponent<Target>();
            //if(target != null)
           // {
               // target.TakeDamage(damage);
               // HitActive();
                //Invoke("HitDisable", 0.2f);
          // }
            
            //Die
            if (hit.transform.tag.Equals("Player"))
            {
                TakeDamage();
                HitActive();
                Invoke("HitDisable", 0.5f);
                //Score Update to Score variable
                scoreBoard.UpdateScore(score = score - 1);
            
            }

            GameObject impactGO = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(impactGO, 2f);
        }  

        void HitActive()
        {
            hitmarker.SetActive(true);
        }

        void HitDisable()
        {
            hitmarker.SetActive(false);
        }
        void TakeDamage()
        {
            currentHealth -= damage;
            if(currentHealth <= 0)
            {
                Destroy(hit.collider.gameObject);
            }
            HealthBar.value = currentHealth;

        }
    }

}
