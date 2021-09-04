using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{

    //Keep Reference to Music Manager, one variable at a time to be shared

    private static MusicManager musicManagerInstance;

    //Call Music Manager Object before any start functions
    void Awake()
    {
        DontDestroyOnLoad(this);

        if (musicManagerInstance == null) {
            musicManagerInstance = this;
        }
        else
        {
            Destroy(gameObject);
        }

    }


}
