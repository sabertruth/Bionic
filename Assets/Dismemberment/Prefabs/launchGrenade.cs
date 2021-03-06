using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class launchGrenade : MonoBehaviour
{
    public float throwForce = 40f;
    public GameObject grenadeprefab;

    //Launch grenade when q is pressed
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.G))
            Launch();
    }

    void Launch()
    {
        GameObject grenade = Instantiate(grenadeprefab, transform.position, transform.rotation);
        Rigidbody rb = grenade.GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * throwForce, ForceMode.VelocityChange);
    }
}
