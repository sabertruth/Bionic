using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Mirror;


public class GunShoot : NetworkBehaviour
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
    public bool killondeath;

    public int Maxammo;

    public Text ammoDisplay;
    public Camera fpsCam;
    public ParticleSystem muzzleFlash;
    public GameObject impactEffect;
    public AudioSource gunSound;
    public GameObject hitmarker;
    public AudioSource reloadSound;

    public Animator animator;

    private float nextTimeToFire = 0f;

    public GameObject charcter;

    public Transform[] spawn_points;

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
            animator.SetBool("isShooting", true);
            nextTimeToFire = Time.time + 1f/fireRate;
            gunSound.Play();
            Shoot();
            ammo--;
            animator.SetBool("isShooting", false);

        }
         if (Input.GetKey(KeyCode.R))
        {

            animator.SetFloat("isReloading", 1);
            reloadSound.Play();
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
            
            //Take Damage
            if (hit.transform.tag.Equals("Enemyplayer"))
            {
                TakeDamage();
                StartCoroutine(HitActive());
                
                scoreBoard.UpdateScore(score = score - 1);
            
            }

            GameObject impactGO = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(impactGO, 2f);
        }  

        IEnumerator HitActive()
        {
            hitmarker.SetActive(true);
            yield return new WaitForSeconds(0.5f);
            hitmarker.SetActive(false);

        }
        void TakeDamage()
        {            
                currentHealth -= damage;
                HealthBar.value = currentHealth;
                if (currentHealth <= 0)
                {
                    if(killondeath)
                    {
                        Destroy(hit.collider.gameObject);
                    }
                    else
                    {
                        currentHealth = Health;
                        RespawnPlayer();
                    }
                }
                Debug.Log(hit.transform.tag);
        }

        void RespawnPlayer()
        {
            Transform t_spawn = spawn_points[UnityEngine.Random.Range(0,spawn_points.Length)];
            charcter = Instantiate(charcter, t_spawn.position, t_spawn.rotation);

        }
    }
}
