using System;
using System.Collections;
using System.Collections.Generic;
using Enumerations;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelectorController : MonoBehaviour
{
    private GameManager m_GameManager;
    private AudioManager m_AudioManager;
    private Vector3 _level1Pos;
    private Vector3 _level2Pos;
    private Vector3 _createLevel1Pos;
    private Vector3 _createLevel2Pos;
    private Vector3 _createLevel3Pos;
    private Vector3 _createLevel4Pos;
    private Vector3 _createLevel5Pos;
    private Vector3 _createLevel6Pos;
    private Vector3 _currentPos;

    //private GameObject _levelCreate1;
    //private GameObject _levelCreate2;
    //private GameObject _levelCreate3;
    //private GameObject _levelCreate4;
    //private GameObject _levelCreate5;
    //private GameObject _levelCreate6;

    private void Awake()
    {
        m_AudioManager = GameObject.FindObjectOfType<AudioManager>();
        _level1Pos = GameObject.Find("txt_level_1").transform.position;
        _level2Pos = GameObject.Find("txt_level_2").transform.position;
        _createLevel1Pos = GameObject.Find("txt_placeholder_1").transform.position;
        _createLevel2Pos = GameObject.Find("txt_placeholder_2").transform.position;
        _createLevel3Pos = GameObject.Find("txt_placeholder_3").transform.position;
        _createLevel4Pos = GameObject.Find("txt_placeholder_4").transform.position;
        _createLevel5Pos = GameObject.Find("txt_placeholder_5").transform.position;
        _createLevel6Pos = GameObject.Find("txt_placeholder_6").transform.position;

        //_levelCreate1 = GameObject.Find("txt_placeholder_1");
        //_levelCreate2 = GameObject.Find("txt_placeholder_2");
        //_levelCreate3 = GameObject.Find("txt_placeholder_3");
        //_levelCreate4 = GameObject.Find("txt_placeholder_4");
        //_levelCreate5 = GameObject.Find("txt_placeholder_5");
        //_levelCreate6 = GameObject.Find("txt_placeholder_6");



    }

    // Start is called before the first frame update
    void Start()
    {
        //for (int i = 6; i > GameSettings.createdLevel; i--)
        //{
        //    GameObject.Find("txt_placeholder_" + i).GetComponent<TextMeshProUGUI>().text = "Not Created!";
        //}

        ////for (int i = 1; i <= 6; i++)
        ////{
        ////    if (i <= GameSettings.createdLevel)
        ////    {
        ////        GameObject.Find("txt_placeholder_" + i).GetComponent<TextMeshProUGUI>().text = "Level " + i;
        ////    }
        ////    else
        ////    {
        ////        GameObject.Find("txt_placeholder_" + i).GetComponent<TextMeshProUGUI>().text = "Not Created!";
        ////    }
        ////}
        m_GameManager = FindObjectOfType<GameManager>();
        _level1Pos.x = _level2Pos.x -= 400;
        _createLevel1Pos.x = _createLevel2Pos.x = _createLevel3Pos.x = _createLevel4Pos.x = _createLevel5Pos.x = _createLevel6Pos.x -= 400;
        GameObject.Find("img_selector").transform.position = _currentPos = _level1Pos;
    }

    // Update is called once per frame
    void Update()
    {
        GenerateLevelList();
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
        else if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            m_AudioManager.PlaySFX(m_AudioManager.bubbleSound);
            Option(_currentPos);
        }
        else if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            m_AudioManager.PlaySFX(m_AudioManager.bubbleSound);
            Option(_currentPos);
        }

        if (Input.GetKeyDown(KeyCode.Return))
        {
            Enter(_currentPos);
        }
    }

    private void GenerateLevelList()
    {
        for (int i = 1; i <= 6; i++)
        {
            if (i <= GameSettings.createdLevel)
            {
                GameObject.Find("txt_placeholder_" + i).GetComponent<TextMeshProUGUI>().text = "Level " + i;
            }
            else
            {
                GameObject.Find("txt_placeholder_" + i).GetComponent<TextMeshProUGUI>().text = "Not Created!";
            }
        }
    }

    private void Option(Vector3 currentPos)
    {
        switch (_currentPos)
        {
            case var pos0 when pos0 == _level1Pos:
            case var pos1 when pos1 == _level2Pos:
                {
                    GameObject.Find("img_selector").transform.position = _currentPos = _createLevel1Pos;
                    break;
                }

            case var pos0 when pos0 == _createLevel1Pos:
            case var pos1 when pos1 == _createLevel2Pos:
            case var pos2 when pos2 == _createLevel3Pos:
            case var pos3 when pos3 == _createLevel4Pos:
            case var pos4 when pos4 == _createLevel5Pos:
            case var pos5 when pos5 == _createLevel6Pos:
                {
                    GameObject.Find("img_selector").transform.position = _currentPos = _level1Pos;
                    break;
                }
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
            case var pos when pos == _createLevel1Pos:
                {
                    if (!GameObject.Find("txt_placeholder_1").GetComponent<TextMeshProUGUI>().text.Equals("Not Created!"))
                    {
                        m_GameManager.Play("Level_1_create");
                    }
                    break;
                }
            case var pos when pos == _createLevel2Pos:
                {
                    if (!GameObject.Find("txt_placeholder_2").GetComponent<TextMeshProUGUI>().text.Equals("Not Created!"))
                    {
                        m_GameManager.Play("Level_2_create");
                    }
                    break;
                }
            case var pos when pos == _createLevel3Pos:
                {
                    if (!GameObject.Find("txt_placeholder_3").GetComponent<TextMeshProUGUI>().text.Equals("Not Created!"))
                    {
                        m_GameManager.Play("Level_3_create");
                    }
                    break;
                }
            case var pos when pos == _createLevel4Pos:
                {
                    if (!GameObject.Find("txt_placeholder_4").GetComponent<TextMeshProUGUI>().text.Equals("Not Created!"))
                    {
                        m_GameManager.Play("Level_4_create");
                    }
                    break;
                }
            case var pos when pos == _createLevel5Pos:
                {
                    if (!GameObject.Find("txt_placeholder_5").GetComponent<TextMeshProUGUI>().text.Equals("Not Created!"))
                    {
                        m_GameManager.Play("Level_5_create");
                    }
                    break;
                }
            case var pos when pos == _createLevel6Pos:
                {
                    if (!GameObject.Find("txt_placeholder_6").GetComponent<TextMeshProUGUI>().text.Equals("Not Created!"))
                    {
                        m_GameManager.Play("Level_6_create");
                    }
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
            case var pos when pos == _createLevel1Pos:
                {
                    GameObject.Find("img_selector").transform.position = _currentPos = _createLevel2Pos;
                    break;
                }
            case var pos when pos == _createLevel2Pos:
                {
                    GameObject.Find("img_selector").transform.position = _currentPos = _createLevel3Pos;
                    break;
                }
            case var pos when pos == _createLevel3Pos:
                {
                    GameObject.Find("img_selector").transform.position = _currentPos = _createLevel4Pos;
                    break;
                }
            case var pos when pos == _createLevel4Pos:
                {
                    GameObject.Find("img_selector").transform.position = _currentPos = _createLevel5Pos;
                    break;
                }
            case var pos when pos == _createLevel5Pos:
                {
                    GameObject.Find("img_selector").transform.position = _currentPos = _createLevel6Pos;
                    break;
                }
            case var pos when pos == _createLevel6Pos:
                {
                    GameObject.Find("img_selector").transform.position = _currentPos = _createLevel1Pos;
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
            case var pos when pos == _createLevel3Pos:
                {
                    GameObject.Find("img_selector").transform.position = _currentPos = _createLevel2Pos;
                    break;
                }
            case var pos when pos == _createLevel4Pos:
                {
                    GameObject.Find("img_selector").transform.position = _currentPos = _createLevel3Pos;
                    break;
                }
            case var pos when pos == _createLevel5Pos:
                {
                    GameObject.Find("img_selector").transform.position = _currentPos = _createLevel4Pos;
                    break;
                }
            case var pos when pos == _createLevel6Pos:
                {
                    GameObject.Find("img_selector").transform.position = _currentPos = _createLevel5Pos;
                    break;
                }
            case var pos when pos == _createLevel1Pos:
                {
                    GameObject.Find("img_selector").transform.position = _currentPos = _createLevel6Pos;
                    break;
                }
            case var pos when pos == _createLevel2Pos:
                {
                    GameObject.Find("img_selector").transform.position = _currentPos = _createLevel1Pos;
                    break;
                }
        }
    }
}