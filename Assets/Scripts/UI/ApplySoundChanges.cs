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

    public void OnMouseDown()
    {
        mixer.SetFloat("MasterVol", master.value);
        mixer.SetFloat("MusicVol", music.value);
        mixer.SetFloat("SoundFXVol", soundfx.value);
        mixer.SetFloat("AmbienceVol", ambience.value);
    }
}
