using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundPlayShot : MonoBehaviour
{
    public AudioSource audioS;
    public AudioClip hit;
    public AudioClip spawn;
    // Start is called before the first frame update
    void Start()
    {
        audioS = GetComponent<AudioSource>();
    }

    public void PlaySpawnSound()
    {
        audioS.PlayOneShot(spawn);
    }

    public void PlayHitSound()
    {
        audioS.PlayOneShot(hit);
    }
}