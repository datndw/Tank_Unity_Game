using System;
using System.Collections;
using DefaultNamespace;
using Entities;
using Enumerations;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using static UnityEditor.Progress;

public class TankController : MonoBehaviour
{
    // Start is called before the first frame update
    private Tank _tank;

    public Sprite tankUp;
    public Sprite tankDown;
    public Sprite tankLeft;
    public Sprite tankRight;
    private TankMover _tankMover;
    private CameraController _cameraController;
    private SpriteRenderer _renderer;
    public new GameObject camera;

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
        //_cameraController = camera.GetComponent<CameraController>();
        _cameraController = GameObject.FindObjectOfType<CameraController>();
        _renderer = gameObject.GetComponent<SpriteRenderer>();
        Move(Direction.Down);
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            Move(Direction.Left);
        }
        else if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            Move(Direction.Down);
        }
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            Move(Direction.Right);
        }
        else if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            Move(Direction.Up);
        }
        if (Input.GetKey(KeyCode.Space))
        {
            Fire();
        }
    }

    private void Move(Direction direction)
    {
        _tank.Position = _tankMover.Move(direction);
        _tank.Direction = direction;
        _cameraController.Move(_tank.Position);
        _renderer.sprite = direction switch
        {
            Direction.Down => tankDown,
            Direction.Up => tankUp,
            Direction.Left => tankLeft,
            Direction.Right => tankRight,
            _ => _renderer.sprite
        };
    }

    private async void Fire()
    {
        Bullet b = new Bullet
        {
            Direction = _tank.Direction,
            //Tank = _tank,
            InitialPosition = _tank.Position
        };
        for (int i = 0; i < _tank.Power; i++)
        {
            GetComponent<TankFirer>().Fire(b, _tank.Power);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Item")
        {
            switch (collision.gameObject.GetComponent<SpriteRenderer>().sprite.name)
            {
                case "powerup_tank":
                    _tankMover.speed += 1;
                    break;
                case "powerup_grenade":
                    _tank.Power += 1;
                    break;
                case "powerup_shovel":

                    break;
            }
            Destroy(collision.gameObject);
        }
    }
}