using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateLevelPanel : MonoBehaviour
{
    private GameManager m_GameManager;
    // Start is called before the first frame update
    void Start()
    {
        m_GameManager = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            MapSaver.Save();
            m_GameManager.Home();
        }
        else if (Input.GetKeyDown(KeyCode.I))
        {
            m_GameManager.Home();
        }
    }
}
