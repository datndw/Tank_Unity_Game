using System;
using System.Collections;
using System.Collections.Generic;
using Entities;
using Enumerations;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    private AudioManager m_AudioManager;
    public Bullet Bullet { get; set; }

    public int MaxRange { get; set; }

    // Start is called before the first frame update
    private void Awake()
    {
        m_AudioManager = GameObject.FindObjectOfType<AudioManager>();
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
            m_AudioManager.PlaySFX(m_AudioManager.bulletHitMetal);
        }
        else if (collision.gameObject.tag == "Grass")
        {
            m_AudioManager.PlaySFX(m_AudioManager.bulletHitGrass);
        }
        else if (collision.gameObject.tag == "Water")
        {
            m_AudioManager.PlaySFX(m_AudioManager.bulletHitWater);
        }
        else
        {
            m_AudioManager.PlaySFX(m_AudioManager.bulletHitBrick);
            Destroy(collision.gameObject);
        }
    }
}