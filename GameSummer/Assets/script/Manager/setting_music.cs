using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class setting_music : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioMixer audioMixer;
    public Slider slider_mus;
    private static float vol = 80f;
    void Start() {
        slider_mus.value = vol;
    }
    void Update() {
        vol = slider_mus.value;    
    }
    public void setVolume(float volume) {
        audioMixer.SetFloat("volume", volume);
    }
}
