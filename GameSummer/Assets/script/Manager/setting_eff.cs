using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class setting_eff : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioMixer audioMixer;
    public Slider slider_eff;
    private static float vol = 80f;
    void Start() {
        slider_eff.value = vol;
    }
    void Update() {
        vol = slider_eff.value;    
    }
    public void setVolume(float volume) {
        audioMixer.SetFloat("volume", volume);
    }
}
