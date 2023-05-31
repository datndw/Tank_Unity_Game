using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager m_Instance;
    [SerializeField] AudioSource musicSource, sfxSource;
    public AudioClip startGame;
    public AudioClip loseGame;
    public AudioClip bulletHitBrick;
    public AudioClip bulletHitMetal;
    public AudioClip bulletHitGrass;
    public AudioClip bulletHitWater;
    public AudioClip bubbleSound;
    
    public static AudioManager Instance
    {
        get
        {
            if (m_Instance == null)
            {
                m_Instance = FindObjectOfType<AudioManager>();
            }
            return m_Instance;
        }
    }

    private void Awake()
    {
        if (m_Instance == null)
        {
            m_Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (m_Instance != this)
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        musicSource.clip = startGame;
        musicSource.Play();
        musicSource.loop = false;
    }

    public void PlaySFX(AudioClip clip)
    {
        sfxSource.PlayOneShot(clip);
    }

    public void SetVolume(float value)
    {
        musicSource.volume = value;
    }
}
