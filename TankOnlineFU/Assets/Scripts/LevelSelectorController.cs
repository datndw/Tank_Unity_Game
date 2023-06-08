using System;
using System.Collections;
using System.Collections.Generic;
using Enumerations;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelectorController : MonoBehaviour
{
    private GameManager m_GameManager;
    private AudioManager m_AudioManager;
    private Vector3 _level1Pos;
    private Vector3 _level2Pos;
    private Vector3 _currentPos;

    private void Awake()
    {
        m_AudioManager = GameObject.FindObjectOfType<AudioManager>();
        _level1Pos = GameObject.Find("txt_level_1").transform.position;
        _level2Pos = GameObject.Find("txt_level_2").transform.position;
    }

    // Start is called before the first frame update
    void Start()
    {
        m_GameManager = FindObjectOfType<GameManager>();
        _level1Pos.x = _level2Pos.x -= 400;
        GameObject.Find("img_selector").transform.position = _currentPos = _level1Pos;
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
        else if(Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            m_AudioManager.PlaySFX(m_AudioManager.bubbleSound);
        }
        else if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            m_AudioManager.PlaySFX(m_AudioManager.bubbleSound);
        }

        if (Input.GetKey(KeyCode.Return))
        {
            Enter(_currentPos);
        }
    }

    private void Enter(Vector3 currentPos)
    {
        switch (currentPos)
        {
            case var pos when pos == _level1Pos:
                {
                    m_GameManager.Play("Level_1");
                    break;
                }
            case var pos when pos == _level2Pos:
                {
                    m_GameManager.Play("Level_2");
                    break;
                }
        }
    }

    private void PreviousOption(Vector3 currentPos)
    {
        switch (_currentPos)
        {
            case var pos when pos == _level1Pos:
                {
                    GameObject.Find("img_selector").transform.position = _currentPos = _level2Pos;
                    break;
                }
            case var pos when pos == _level2Pos:
                {
                    GameObject.Find("img_selector").transform.position = _currentPos = _level1Pos;
                    break;
                }

        }
    }

    private void NextOption(Vector3 currentPos)
    {
        switch (_currentPos)
        {
            case var pos when pos == _level1Pos:
                {
                    GameObject.Find("img_selector").transform.position = _currentPos = _level2Pos;
                    break;
                }
            case var pos when pos == _level2Pos:
                {
                    GameObject.Find("img_selector").transform.position = _currentPos = _level1Pos;
                    break;
                }
        }
    }
}
