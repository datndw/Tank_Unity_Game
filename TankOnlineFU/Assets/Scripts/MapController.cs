using Entities;
using TMPro.Examples;
using UnityEngine;

public class MapController : MonoBehaviour
{
    [SerializeField] private GameObject m_Cell;
    [SerializeField] private GameObject m_Brick;
    [SerializeField] private GameObject m_Stone;
    [SerializeField] private GameObject m_Player;
    private Map Map;
    private Cell Cell;

    private void Awake()
    {
        Map = GameSettings.Map;
    }
    // Start is called before the first frame update
    void Start()
    {
        m_Cell.transform.position = m_Brick.transform.position = m_Player.transform.position = new Vector3(0, 0, 0);
        for (int i = 0; i < Map.Column; i++)
        {
            for (int j = 0; j < Map.Row; j++)
            {
                Instantiate(m_Cell, m_Cell.transform.position + new Vector3(i, j, 0), m_Cell.transform.rotation);
            }
        }
        foreach(Position pos in Map.Bricks)
        {
            Instantiate(m_Brick, m_Brick.transform.position + new Vector3(pos.Column, pos.Row,0), m_Brick.transform.rotation);
        }
        foreach (Position pos in Map.Stones)
        {
            Instantiate(m_Stone, m_Stone.transform.position + new Vector3(pos.Column, pos.Row, 0), m_Stone.transform.rotation);
        }
        foreach (Position pos in Map.Players)
        {
            Instantiate(m_Player, m_Player.transform.position, m_Player.transform.rotation);
        }

    }

    // Update is called once per frame
    void Update()
    {
    }
}
