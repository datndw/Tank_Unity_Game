using System.Collections;
using System.Collections.Generic;
using Entities;
using UnityEngine;

public class MapController : MonoBehaviour
{
    [SerializeField] private GameObject m_Cell;
    private Map Map;
    private Cell Cell;

    private void Awake()
    {
        Map = GameSettings.Map;
        Cell = new Cell();
        Cell.Width = Screen.width / Map.Column;
        Cell.Height = Screen.height / Map.Row;
    }
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < Map.Column; i++)
        {
            for (int j = 0; j < Map.Row; j++)
            {
                Instantiate(m_Cell,m_Cell.transform.position + new Vector3(i,j,0), m_Cell.transform.rotation);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
    }
}
