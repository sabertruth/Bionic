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
            animator.SetBool("isScoped",isScoped);
            
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
        fpsCam.cullingMask = fpsCam.cullingMask & ~(1 << 11);
        fpsCam.cullingMask = fpsCam.cullingMask & ~(1 << 6);
        weaponsCam.gameObject.SetActive(false);
    }
    void OnUnscoped()
    {
        animator.SetBool("isScoped", false);
        fpsCam.fieldOfView = 60;
        scopeOverlay.SetActive(false);
        fpsCam.cullingMask = fpsCam.cullingMask | (1 << 11);
        fpsCam.cullingMask = fpsCam.cullingMask | (1 << 6);
        weaponsCam.gameObject.SetActive(true);
    }
}

