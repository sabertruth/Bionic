using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundAnnouncerScript : MonoBehaviour {

    public static AudioClip playerDeathSound, enemyDeathSound, killStreakOneSound, killStreakTwoSound, killStreakThreeSound;
    static AudioSource audioSrc;

    // Start is called before the first frame update
    void Start() {
        
        PlayerDeathSound = usedsounds.load<AudioClip> ("playerDeathSound");
        PlayerDeathSound = usedsounds.load<AudioClip> ("enemyDeathSound");
        PlayerDeathSound = usedsounds.load<AudioClip> ("KillStreakOneSound");
        PlayerDeathSound = usedsounds.load<AudioClip> ("KillStreakTwoSound");
        PlayerDeathSound = usedsounds.load<AudioClip> ("KillStreakThreeSound");

        audioSrc = GetComponent<AudioSource> ();

    }

    // Update is called once per frame
    void Update() {
    }

        public static void Playsound (string clip) {
            
            switch (clip) {
            case "playerDeathSound"
                audioSrc.PlayOneShot (playerDeathSound);
                break;
            case "enemyDeathSound"
                audioSrc.PlayOneShot (enemyDeathSound);
                break;
            case "KillStreakOneSound"
                audioSrc.PlayOneShot (KillStreakOneSound);
                break;
            case "KillStreakTwoSound"
                audioSrc.PlayOneShot (KillStreakTwoSound);
                break;    
            case "KillStreakThreeSound"
                audioSrc.PlayOneShot (KillStreakThreeSound);
                break;    
            }
        }


    
}
