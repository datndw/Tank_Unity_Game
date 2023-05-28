using System;
using System.Collections;
using System.Collections.Generic;
using Enumerations;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager m_Instance;
    public static GameManager Instance
    {
        get
        {
            if(m_Instance == null)
            {
                m_Instance = FindObjectOfType<GameManager>();
            }
            return m_Instance;
        }
    }

    [SerializeField] private HomePanel m_HomePanel;
    [SerializeField] private GameplayPanel m_GameplayPanel;
    [SerializeField] private PausePanel m_PausePanel;
    [SerializeField] private GameoverPanel m_GameoverPanel;
    [SerializeField] private ConstructionPanel m_ConstructionPanel;
    [SerializeField] private CreateLevelPanel m_CreateLevelPanel;
    [SerializeField] private LevelManager m_LevelManager;

    [HideInInspector] private GameState m_GameState;
    [HideInInspector] bool m_Win;


    private void Awake()
    {
        if (m_Instance == null)
        {
            m_Instance = this;
        }else if( m_Instance != this)
        {
            Destroy(gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        m_HomePanel.gameObject.SetActive(false);
        m_GameplayPanel.gameObject.SetActive(false);
        m_PausePanel.gameObject.SetActive(false);
        m_GameoverPanel.gameObject.SetActive(false);
        m_ConstructionPanel.gameObject.SetActive(false);
        m_CreateLevelPanel.gameObject.SetActive(false);
        SetState(GameState.Home);
    }

    private void SetState(GameState state)
    {
        m_GameState = state;
        m_HomePanel.gameObject.SetActive(m_GameState == GameState.Home);
        m_GameplayPanel.gameObject.SetActive(m_GameState == GameState.GamePlay);
        m_PausePanel.gameObject.SetActive(m_GameState == GameState.Pause);
        m_GameoverPanel.gameObject.SetActive(m_GameState == GameState.GameOver);
        m_ConstructionPanel.gameObject.SetActive(m_GameState == GameState.Construction);
        m_CreateLevelPanel.gameObject.SetActive(m_GameState == GameState.CreateLevel);

        if (m_GameState == GameState.Pause)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public bool IsActive() {
        return m_GameState == GameState.GamePlay;
    }

    public void Play()
    {
        SetState(GameState.GamePlay);
    }

    public void Construction()
    {
        SetState(GameState.Construction);
    }

    public void CreateLevel()
    {
        SetState(GameState.CreateLevel);
    }

    public void Pause()
    {
        SetState(GameState.Pause);
    }

    public void Continue()
    {
        SetState(GameState.GamePlay);
    }

    public void Gameover(bool win)
    {
        m_Win = win;
        SetState(GameState.GameOver);
        //m_GameoverPanel.DisplayResult(m_Win);
    }
    public void NextLevel()
    {
        string nextLevel = m_LevelManager.GetNextLevel();
        if (!string.IsNullOrEmpty(nextLevel))
        {
            SceneManager.LoadScene(nextLevel);
        }
        else
        {
            Debug.LogWarning("No more level");
        }
    }

    public void Restart()
    {

    }
}
