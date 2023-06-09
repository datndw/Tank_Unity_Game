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

    }

    public void BtnSave_Pressed()
    {
        MapSaver.Save();
        m_GameManager.Home();
    }

    public void BtnDiscard_Pressed()
    {
        m_GameManager.Home();
    }
}
