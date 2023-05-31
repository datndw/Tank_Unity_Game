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
    public void SetMusicVolume()
    {
        float volume = musicSlider.value;
        m_AudioManager.SetVolume(volume);
    }
}
