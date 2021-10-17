using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class Scope : MonoBehaviour
{
    public Animator animator;
    
    public GameObject scopeOverlay;
    
    private bool isScoped = false;
    public Camera fpsCam;
    public Camera weaponsCamera;
    
    public float scopedFOV;
    private float normalFOV;
 
    void Update()
    {
        
         if(Input.GetButtonDown("Fire2"))
         {
             isScoped = !isScoped;
             animator.SetBool("Scoped", isScoped);
                
             if (isScoped)
             {
               StartCoroutine(OnScoped());
             }
             else
             {
                OnUnscoped();
             }
        }

    }
    void OnUnscoped()
    {
        scopeOverlay.SetActive(false);
        weaponsCamera.SetActive(true);

        fpsCam.fieldOfView = normalFOV;
    }
    IEnumerator OnScoped()
    {
       yield return new WaitForSeconds(.15f);

       scopeOverlay.SetActive(true);
       weaponsCamera.SetActive(false);

       normalFOV = fpsCam.fieldOfView;
       fpsCam.fieldOfView = scopedFOV;
    }
}