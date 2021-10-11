using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class launchGrenade : MonoBehaviour
{
    public Transform spawnPoint;
    public GameObject grenade;

    float range =10f;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q))
            Launch();
    }

    void Launch()
    {
        GameObject grenadeInstance = Instantiate(grenade, spawnPoint.position, spawnPoint.rotation);
        grenadeInstance.GetComponent<Rigidbody>().AddForce(spawnPoint.forward * range, ForceMode.Impulse);
    }
}
