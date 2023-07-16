using System;
using System.Collections;
using System.Collections.Generic;
using Entities;
using Enumerations;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    private AudioManager m_AudioManager;
    public Animator animator;
    public Bullet Bullet { get; set; }

    public int MaxRange { get; set; }

    private GameManager m_GameManager;

    // Start is called before the first frame update
    private void Awake()
    {
        m_AudioManager = GameObject.FindObjectOfType<AudioManager>();
        m_GameManager = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    private void Update()
    {
        DestroyAfterRange();
    }

    private void DestroyAfterRange()
    {
        var currentPos = gameObject.transform.position;
        var initPos = Bullet.InitialPosition;
        switch (Bullet.Direction)
        {
            case Direction.Down:
                if (initPos.y - MaxRange >= currentPos.y)
                {
                    Destroy(gameObject);
                }

                break;
            case Direction.Up:
                if (initPos.y + MaxRange <= currentPos.y)
                {
                    Destroy(gameObject);
                }

                break;
            case Direction.Left:
                if (initPos.x - MaxRange >= currentPos.x)
                {
                    Destroy(gameObject);
                }

                break;
            case Direction.Right:
                if (initPos.x + MaxRange <= currentPos.x)
                {
                    Destroy(gameObject);
                }
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Metal")
        {
            //animation
            m_AudioManager.PlaySFX(m_AudioManager.bulletHitMetal);
            Destroy(gameObject);
        }
        else if (collision.gameObject.tag == "Grass")
        {
            m_AudioManager.PlaySFX(m_AudioManager.bulletHitGrass);
        }
        else if (collision.gameObject.tag == "Water")
        {
            m_AudioManager.PlaySFX(m_AudioManager.bulletHitWater);
        }
        else if (collision.gameObject.tag == "Brick")
        {
            m_AudioManager.PlaySFX(m_AudioManager.bulletHitBrick);
            //animation
            animator.SetTrigger("bulletHit");
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
        else if (collision.gameObject.tag == "Base")
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
            m_GameManager.Gameover();
        }
        else if (collision.gameObject.tag == "Enemy")
        {
            //animation
            Destroy(gameObject);
        }
        else if (collision.gameObject.tag == "Player")
        {
            // Destroy(collision.gameObject);
            Destroy(gameObject);
            // m_GameManager.Gameover();
        }
        else if (collision.gameObject.tag == "bulletEnemy")
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}