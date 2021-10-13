// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class SoundAnnouncerScript : MonoBehaviour {

//     public static AudioClip playerDeathSound, enemyDeathSound, KillStreakOneSound, KillStreakTwoSound, KillStreakThreeSound;
//     static AudioSource audioSrc;

//     // Start is called before the first frame update
//     void Start() {
        
//         playerDeathSound = usedSounds.load<AudioClip> ("playerDeathSound");
//         enemyDeathSound = usedSounds.load<AudioClip> ("enemyDeathSound");
//         KillStreakOneSound = usedSounds.load<AudioClip> ("KillStreakOneSound");
//         KillStreakTwoSound = usedSounds.load<AudioClip> ("KillStreakTwoSound");
//         KillStreakThreeSound = usedSounds.load<AudioClip> ("KillStreakThreeSound");

//         audioSrc = GetComponent<AudioSource> ();

//     }

//     // Update is called once per frame
//     void Update() {
//     }

//         public static void Playsound (string clip) {
            
//             switch (clip) {
//             case "playerDeathSound":
//                 audioSrc.PlayOneShot (playerDeathSound);
//                 break;
//             case "enemyDeathSound":
//                 audioSrc.PlayOneShot (enemyDeathSound);
//                 break;
//             case "KillStreakOneSound":
//                 audioSrc.PlayOneShot (KillStreakOneSound);
//                 break;
//             case "KillStreakTwoSound":
//                 audioSrc.PlayOneShot (KillStreakTwoSound);
//                 break;    
//             case "KillStreakThreeSound":
//                 audioSrc.PlayOneShot (KillStreakThreeSound);
//                 break;    
//             }
//         }


    
// }
