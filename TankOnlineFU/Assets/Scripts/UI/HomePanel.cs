using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HomePanel : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI m_PlayerScore;
    [SerializeField] private TextMeshProUGUI m_HighScore;

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
}
