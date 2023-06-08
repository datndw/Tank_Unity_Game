using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseController : MonoBehaviour
{
    private GameManager m_GameManager;
    private int health = 50;
    // Start is called before the first frame update
    void Start()
    {
        m_GameManager = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            m_GameManager.Gameover(false);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            health -= 10;
        }
    }
}
