using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using Entities;
using Enumerations;
using TMPro.Examples;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    private Tank _tank;
    private GameManager m_GameManager;
    public Sprite tankUp;
    public Sprite tankDown;
    public Sprite tankLeft;
    public Sprite tankRight;
    private TankMover _tankMover;
    private SpriteRenderer _renderer;
    public Transform target; // The player's tank transform
    public float moveSpeed = 3f;
    public int health;

    private void Awake()
    {
        m_GameManager = FindObjectOfType<GameManager>();
    }
    private void Start()
    {
        _tank = new Tank
        {
            Name = "Default",
            Direction = Direction.Down,
            Hp = 10,
            Point = 0,
            Position = new Vector3(gameObject.gameObject.transform.position.x, gameObject.gameObject.transform.position.y, 0),
            Power = 1,
            Guid = GUID.Generate()
        };
        gameObject.transform.position = _tank.Position;
        _tankMover = gameObject.GetComponent<TankMover>();
        _renderer = gameObject.GetComponent<SpriteRenderer>();
        Move(Direction.Down);
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    private void Update()
    {
        if (target != null)
        {
            Vector3 targetPosition = new Vector3(target.position.x, target.position.y, transform.position.z);
            if ((int)targetPosition.x > (int)transform.position.x)
            {
                Move(Direction.Right);
            }
            else if ((int)targetPosition.x < (int)transform.position.x)
            {
                Move(Direction.Left);
            }
            else if ((int)targetPosition.y > (int)transform.position.y)
            {
                Move(Direction.Up);
            }
            else if ((int)targetPosition.y < (int)transform.position.y)
            {
                Move(Direction.Down);
            }
            Fire();
        }
    }

    private void Move(Direction direction)
    {

        _tankMover.speed = 1;
        _tank.Position = _tankMover.Move(direction);
        _tank.Direction = direction;
        _renderer.sprite = direction switch
        {
            Direction.Down => tankDown,
            Direction.Up => tankUp,
            Direction.Left => tankLeft,
            Direction.Right => tankRight,
            _ => _renderer.sprite
        };
    }

    private void Fire()
    {
        Bullet b = new Bullet
        {
            Direction = _tank.Direction,
            //Tank = _tank,
            InitialPosition = _tank.Position
        };
        GetComponent<TankFirer>().Fire(b, _tank.Power);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("bullet"))
        {
            health -= 10;
            if (health <= 0)
            {
                Destroy(gameObject);
                var enemy=GameObject.FindGameObjectsWithTag("Enemy");
                Debug.Log(enemy.Length);
                if(enemy.Length<=1){
                    m_GameManager.Gamewon();
                }
            }
        }
    }
}
