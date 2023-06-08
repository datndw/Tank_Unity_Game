using System;
using System.Collections;
using System.Collections.Generic;
using Enumerations;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectorController : MonoBehaviour
{
    private GameManager m_GameManager;
    private AudioManager m_AudioManager;
    private Vector3 _singlePlayerPos;
    private Vector3 _multiplePlayerPos;
    private Vector3 _createLevelPos;
    private Vector3 _constructionPos;
    private Vector3 _currentPos;

    private void Awake()
    {
        m_AudioManager = GameObject.FindObjectOfType<AudioManager>();
        _singlePlayerPos = GameObject.Find("txt_single_player").transform.position;
        _multiplePlayerPos = GameObject.Find("txt_multiple_players").transform.position;
        _createLevelPos = GameObject.Find("txt_create_level").transform.position;
        _constructionPos = GameObject.Find("txt_construction").transform.position;
    }

    // Start is called before the first frame update
    void Start()
    {
        m_GameManager = FindObjectOfType<GameManager>();
        _singlePlayerPos.x = _multiplePlayerPos.x = _createLevelPos.x = _constructionPos.x -= 400;
        GameObject.Find("img_selector").transform.position = _currentPos = _singlePlayerPos;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            m_AudioManager.PlaySFX(m_AudioManager.bubbleSound);
            NextOption(_currentPos);

        }
        else if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            m_AudioManager.PlaySFX(m_AudioManager.bubbleSound);
            PreviousOption(_currentPos);
        }

        if (Input.GetKey(KeyCode.Return))
        {
            //m_GameManager.Play();
            Enter(_currentPos);
        }
    }

    private void Enter(Vector3 currentPos)
    {
        switch (currentPos)
        {
            case var pos when pos == _singlePlayerPos:
                {
                    m_GameManager.ChooseLevel();
                    break;
                }
            case var pos when pos == _multiplePlayerPos:
                {
                    GameSettings.isMultiplePlayer = true;
                    m_GameManager.ChooseLevel();
                    break;
                }
            case var pos when pos == _createLevelPos:
                {
                    m_GameManager.CreateLevel();
                    break;
                }
            case var pos when pos == _constructionPos:
                {
                    m_GameManager.Construction();
                    break;
                }
        }
    }

    private void PreviousOption(Vector3 currentPos)
    {
        switch (_currentPos)
        {
            case var pos when pos == _singlePlayerPos:
                {
                    GameObject.Find("img_selector").transform.position = _currentPos = _constructionPos;
                    break;
                }
            case var pos when pos == _multiplePlayerPos:
                {
                    GameObject.Find("img_selector").transform.position = _currentPos = _singlePlayerPos;
                    break;
                }
            case var pos when pos == _createLevelPos:
                {
                    GameObject.Find("img_selector").transform.position = _currentPos = _multiplePlayerPos;
                    break;
                }
            case var pos when pos == _constructionPos:
                {
                    GameObject.Find("img_selector").transform.position = _currentPos = _createLevelPos;
                    break;
                }

        }
    }

    private void NextOption(Vector3 currentPos)
    {
        switch (_currentPos)
        {
            case var pos when pos == _singlePlayerPos:
                {
                    GameObject.Find("img_selector").transform.position = _currentPos = _multiplePlayerPos;
                    break;
                }
            case var pos when pos == _multiplePlayerPos:
                {
                    GameObject.Find("img_selector").transform.position = _currentPos = _createLevelPos;
                    break;
                }
            case var pos when pos == _createLevelPos:
                {
                    GameObject.Find("img_selector").transform.position = _currentPos = _constructionPos;
                    break;
                }
            case var pos when pos == _constructionPos:
                {
                    GameObject.Find("img_selector").transform.position = _currentPos = _singlePlayerPos;
                    break;
                }
        }
    }
}
