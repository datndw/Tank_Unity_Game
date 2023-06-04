using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayPanel : MonoBehaviour
{
    private GameManager m_GameManager;
    public static AudioManager m_AudioInstance;

    private void Awake()
    {
        m_AudioInstance = GameObject.FindObjectOfType<AudioManager>();
    }
    // Start is called before the first frame update
    void Start()
    {
        m_GameManager = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BtnPause_Pressed()
    {
        m_GameManager.Pause();
    }
}
