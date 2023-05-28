using System;
using System.Collections;
using System.Collections.Generic;
using Enumerations;
using UnityEngine;

public class SelectorController : MonoBehaviour
{
    private Vector3 _singlePlayerPos;
    private Vector3 _multiplePlayerPos;
    private Vector3 _createLevelPos;
    private Vector3 _constructionPos;
    private Vector3 _currentPos;

    private void Awake()
    {
        _singlePlayerPos = GameObject.Find("txt_single_player").transform.position;
        _multiplePlayerPos = GameObject.Find("txt_multiple_players").transform.position;
        _createLevelPos = GameObject.Find("txt_create_level").transform.position;
        _constructionPos = GameObject.Find("txt_construction").transform.position;
    }

    // Start is called before the first frame update
    void Start()
    {
        _singlePlayerPos.x = _multiplePlayerPos.x = _createLevelPos.x = _constructionPos.x -= 400;
        GameObject.Find("img_selector").transform.position = _currentPos = _singlePlayerPos;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {

            NextOption(_currentPos);

        }
        else if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            PreviousOption(_currentPos);
        }

        if (Input.GetKey(KeyCode.Return))
        {

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
