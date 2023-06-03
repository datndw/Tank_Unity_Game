using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeSetting : MonoBehaviour
{
    private AudioManager m_AudioManager;
    [SerializeField] Slider musicSlider, sfxSlider;

    private void Awake()
    {
        m_AudioManager = GameObject.FindObjectOfType<AudioManager>();
    }
    private void Start()
    {
        musicSlider.value = sfxSlider.value = 5;
        m_AudioManager.SetVolume("Music", 5);
        m_AudioManager.SetVolume("Sfx", 5);
    }
    public void SetMusicVolume()
    {
        float volume = musicSlider.value;
        m_AudioManager.SetVolume("Music", volume);
    }
    public void SetSfxVolume()
    {
        float volume = sfxSlider.value;
        m_AudioManager.SetVolume("Sfx", volume);
    }
}
