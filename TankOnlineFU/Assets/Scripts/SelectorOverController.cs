using System;
using System.Collections;
using System.Collections.Generic;
using Enumerations;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectorOverController : MonoBehaviour
{
    private GameManager m_GameManager;
    private AudioManager m_AudioManager;
    private Vector3 _backToHomePos;
    private Vector3 _exitPos;
    private Vector3 _currentPos;

    private void Awake()
    {
        m_AudioManager = GameObject.FindObjectOfType<AudioManager>();
        _backToHomePos = GameObject.Find("txt_back_to_home").transform.position;
        _exitPos = GameObject.Find("txt_exit").transform.position;
    }

    // Start is called before the first frame update
    void Start()
    {
        m_GameManager = FindObjectOfType<GameManager>();
        _backToHomePos.x = _exitPos.x -= 400;
        GameObject.Find("img_selector").transform.position = _currentPos = _backToHomePos;
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

        if (Input.GetKeyDown(KeyCode.Return))
        {
            Enter(_currentPos);
        }
    }

    private void Enter(Vector3 currentPos)
    {
        switch (currentPos)
        {
            case var pos when pos == _backToHomePos:
                {
                    m_GameManager.Home();
                    break;
                }
            case var pos when pos == _exitPos:
                {
                    Application.Quit();
                    break;
                }
        }
    }

    private void PreviousOption(Vector3 currentPos)
    {
        switch (_currentPos)
        {
            case var pos when pos == _backToHomePos:
                {
                    GameObject.Find("img_selector").transform.position = _currentPos = _exitPos;
                    break;
                }
            case var pos when pos == _exitPos:
                {
                    GameObject.Find("img_selector").transform.position = _currentPos = _backToHomePos;
                    break;
                }
        }
    }

    private void NextOption(Vector3 currentPos)
    {
        switch (_currentPos)
        {
            case var pos when pos == _exitPos:
                {
                    GameObject.Find("img_selector").transform.position = _currentPos = _backToHomePos;
                    break;
                }
            case var pos when pos == _backToHomePos:
                {
                    GameObject.Find("img_selector").transform.position = _currentPos = _exitPos;
                    break;
                }
        }
    }
}
