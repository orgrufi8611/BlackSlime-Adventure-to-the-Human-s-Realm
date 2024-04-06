using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AudioManagment : MonoBehaviour
{
    public Slider soundEffectSlider;
    public TextMeshProUGUI volume;
    float soundEffectFloat;
    AudioSource[] audioSources;
    // Start is called before the first frame update
    void Start()
    {
        soundEffectFloat = 0.5f;
        soundEffectSlider.value = soundEffectFloat;
        audioSources = GameObject.FindSceneObjectsOfType(typeof(AudioSource)) as AudioSource[];
        
    }

    public void ResetOnNewScene()
    {
        audioSources = null;
        Start();
    }

    // Update is called once per frame
    void Update()
    {
        soundEffectFloat = soundEffectSlider.value;
        volume.text = "Volume: " + ((int)(soundEffectFloat*100)).ToString();
        foreach (AudioSource source in audioSources)
        {
            source.volume = soundEffectSlider.value;
        }
    }
}

