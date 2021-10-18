using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class Scope : MonoBehaviour
{
    public Animator animator;
    public GameObject scopeOverlay;
    private bool isScoped = false;
    public Camera fpsCam;
    public GameObject weaponsCam;
    

    void Update()
    {
        if(Input.GetMouseButtonDown(1))
        {
            isScoped = !isScoped;
            animator.SetBool("scope",isScoped);
            
            if(isScoped)
              StartCoroutine(OnScoped());
            else
            OnUnscoped();

        }
    }
    IEnumerator OnScoped()
    {
        animator.SetBool("isScoped", true);
        yield return new WaitForSeconds(0.5f);
        fpsCam.fieldOfView = 45;
        scopeOverlay.SetActive(true);
        weaponsCam.gameObject.SetActive(false);
    }
    void OnUnscoped()
    {
        animator.SetBool("isScoped", false);
        fpsCam.fieldOfView = 60;
        scopeOverlay.SetActive(false);
        weaponsCam.gameObject.SetActive(true);
    }
}

