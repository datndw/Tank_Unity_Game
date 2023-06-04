using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PausePanel : MonoBehaviour
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

    public void BtnContinue_Pressed()
    {
        m_GameManager.Continue();
    }

    public void BtnExit_Pressed()
    {
        m_GameManager.Start();
    }
}
