using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeSettings : MonoBehaviour
{
    [SerializeField] AudioMixer audioMixer;
    [SerializeField] Slider musicSilder;
    [SerializeField] Slider vfxSilder;
    const string MIXER_MUSIC = "MusicVolume";
    const string MIXER_VFX = "VfxVolume";
    void Awake()
    {
        musicSilder.onValueChanged.AddListener(SetMusicVolume);
        vfxSilder.onValueChanged.AddListener(SetVfxVolume);
    }
    void SetMusicVolume(float value)
    {
        audioMixer.SetFloat(MIXER_MUSIC, Mathf.Log10(value) * 20);
    }
    void SetVfxVolume(float value)
    {
        audioMixer.SetFloat(MIXER_VFX, Mathf.Log10(value) * 20);
    }
}
