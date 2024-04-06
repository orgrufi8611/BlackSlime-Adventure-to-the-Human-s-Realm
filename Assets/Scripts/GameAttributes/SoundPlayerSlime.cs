using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundPlayerSlime : MonoBehaviour
{
    public AudioSource audioS;
    public AudioClip jump;
    public AudioClip walk;
    public bool walking;
    float timepassSound;
    float soundIntervals;
    // Start is called before the first frame update
    void Start()
    {
        audioS = GetComponent<AudioSource>();
        audioS.loop = true;
        audioS.Play();
        timepassSound = Mathf.Infinity;
        soundIntervals = walk.length;
    }

    private void Update()
    {
        timepassSound += Time.deltaTime;
        if(timepassSound > soundIntervals && walking)
        {
            PlayWalkSound();
            timepassSound = 0;
        }
    }

    public void PlayJumpSound()
    {
        audioS.PlayOneShot(jump);
    }

    public void PlayWalkSound()
    {
        audioS.PlayOneShot(walk);
    }

}
