using System;
using DefaultNamespace;
using Entities;
using Enumerations;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class BuilderController : MonoBehaviour
{
    // Start is called before the first frame update
    private Tank _tank;

    public Sprite tankUp;
    public Sprite tankDown;
    public Sprite tankLeft;
    public Sprite tankRight;
    private BuilderDasher _builderDasher;
    private CameraController _cameraController;
    private SpriteRenderer _renderer;
    public new GameObject camera;
    public float blinkInterval = 0.5f;
    private string buildingBlock = "";

    public GameObject Brick;
    public GameObject Metal;
    public GameObject Bush;
    public GameObject Water;


    private void Start()
    {
        _tank = new Tank
        {
            Name = "Default",
            Direction = Direction.Down,
            Hp = 10,
            Point = 0,
            Position = new Vector3(10, 10, 0),
            Guid = GUID.Generate()
        };
        gameObject.transform.position = _tank.Position;
        _builderDasher = gameObject.GetComponent<BuilderDasher>();
        _cameraController = GameObject.FindObjectOfType<CameraController>();
        _renderer = gameObject.GetComponent<SpriteRenderer>();
        Move(Direction.Down);
        InvokeRepeating("ToggleVisibility", blinkInterval, blinkInterval);
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            Move(Direction.Left);
            Deploy(buildingBlock);
        }
        else if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            Move(Direction.Down);
            Deploy(buildingBlock);
        }
        else if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            Move(Direction.Right);
            Deploy(buildingBlock);
        }
        else if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            Move(Direction.Up);
            Deploy(buildingBlock);
        }
        if (Input.GetKey(KeyCode.Space))
        {
            
        }
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            buildingBlock = "Brick";
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            buildingBlock = "Metal";
        }
    }

    private void Deploy(string buildingBlock)
    {
        if (buildingBlock.Equals(nameof(Brick))){
            Instantiate(Brick, _tank.Position,Quaternion.identity );
            GameSettings.Map.Bricks.Add(new Position((int)_tank.Position.y,(int)_tank.Position.x));
        }else if(buildingBlock.Equals(nameof(Metal))){
            Instantiate(Metal, _tank.Position, Quaternion.identity);
            GameSettings.Map.Stones.Add(new Position((int)_tank.Position.y, (int)_tank.Position.x));
        }
    }

    private void Move(Direction direction)
    {
        _tank.Position = _builderDasher.Dash(direction);
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

    void ToggleVisibility()
    {
        _renderer.enabled = !_renderer.enabled;
    }
}