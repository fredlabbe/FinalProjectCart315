using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour 
{
    public static AudioClip playerHitSound, enemyHitSound, swordSound;
    static AudioSource audioSrc;

    // Start is called before the first frame update
    void Start()
    {
        playerHitSound = Resources.Load<AudioClip>("playerHit");
        enemyHitSound = Resources.Load<AudioClip>("enemyHit");
        swordSound = Resources.Load<AudioClip>("swordclash01");

        audioSrc = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    } 

    public static void PlaySound(string clip)
    {
        switch (clip)
        {
            case "playerHit":
                audioSrc.PlayOneShot(playerHitSound);
                break;
            case "enemyHit":
                audioSrc.PlayOneShot(enemyHitSound);
                break;
            case "swordclash01":
                audioSrc.PlayOneShot(swordSound);
                break;
        }
    }
}
