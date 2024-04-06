using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundPlayerEnemy : MonoBehaviour
{
    public AudioSource audioS;
    public AudioClip spawn;
    public AudioClip hit;
    public AudioClip death;
    // Start is called before the first frame update
    void Start()
    {
        audioS = GetComponent<AudioSource>();
        PlaySpawnSound();
    }

    public void PlaySpawnSound()
    {
        audioS.PlayOneShot(spawn);
    }

    public void PlayDeathSound()
    {
        audioS.PlayOneShot(death);
    }

    public void PlayHitSound()
    {
        audioS.PlayOneShot(hit);
    }
}
