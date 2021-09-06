using UnityEngine;

public class Volume_Manager : MonoBehaviour
{

    private AudioSource audioSrc;


    private float musicVolume = 1f;


    void Start()
    {

        //Audio Source component assigned
        audioSrc = GetComponent<AudioSource>();
    }

    // Volume is updated per frame
    void Update()
    {

        // Setting volume option of Audio Source to be equal to musicVolume
        audioSrc.volume = musicVolume;
    }


    public void SetVolume(float vol)
    {
        musicVolume = vol;
    }
}