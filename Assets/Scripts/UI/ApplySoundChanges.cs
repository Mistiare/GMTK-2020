using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class ApplySoundChanges : MonoBehaviour
{
    [SerializeField]
    AudioMixer mixer;
    [SerializeField]
    Slider master;
    [SerializeField]
    Slider music;
    [SerializeField]
    Slider soundfx;
    [SerializeField]
    Slider ambience;

    private void Start()
    {
        master.value = PlayerPrefs.GetFloat("MasterVol");
        music.value = PlayerPrefs.GetFloat("MusicVol");
        ambience.value = PlayerPrefs.GetFloat("AmbienceVol");
        soundfx.value = PlayerPrefs.GetFloat("SoundFXVol");
    }
    
    public void OnMouseDown()
    {
        mixer.SetFloat("MasterVol", master.value);
        mixer.SetFloat("MusicVol", music.value);
        mixer.SetFloat("SoundFXVol", soundfx.value);
        mixer.SetFloat("AmbienceVol", ambience.value);
        PlayerPrefs.SetFloat("MasterVol", master.value);
        PlayerPrefs.SetFloat("SoundFXVol", soundfx.value);
        PlayerPrefs.SetFloat("AmbienceVol", ambience.value);
        PlayerPrefs.SetFloat("MusicVol", music.value);
        PlayerPrefs.Save();
    }
}
