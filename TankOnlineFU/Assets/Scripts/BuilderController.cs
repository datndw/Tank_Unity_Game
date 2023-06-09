using System;
using System.Collections.Generic;
using DefaultNamespace;
using Entities;
using Enumerations;
using TMPro;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using Object = UnityEngine.Object;

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
    public GameObject Enemy;
    public GameObject Player;
    public GameObject Base;

    public bool isDeploying = false;


    private void Start()
    {
        _tank = new Tank
        {
            Name = "Default",
            Direction = Direction.Down,
            Hp = 10,
            Point = 0,
            Position = new Vector3(15, 15, 0),
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
        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            buildingBlock = "";
        }
        else if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            buildingBlock = "Brick";
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            buildingBlock = "Metal";
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            buildingBlock = "Water";
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            buildingBlock = "Bush";
        }
        else if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            buildingBlock = "Enemy";
        }
        else if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            buildingBlock = "Player";
        }
        else if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            buildingBlock = "Base";
        }
        else if (Input.GetKeyDown(KeyCode.E)){
            buildingBlock = "";
            DestroyPrefabsAtPosition(gameObject.transform.position);
        }
    }

    private void DestroyPrefabsAtPosition(Vector3 position)
    {
        List<GameObject> gobjs = new();
        foreach(GameObject gobj in GameObject.FindGameObjectsWithTag("Brick"))
        {
            gobjs.Add(gobj);
            GameSettings.Map.Bricks.RemoveAll(x => x.Column == (int)_tank.Position.x && x.Row == (int)_tank.Position.y) ;
        }

        foreach (GameObject gobj in GameObject.FindGameObjectsWithTag("Metal"))
        {
            gobjs.Add(gobj);
            GameSettings.Map.Stones.RemoveAll(x => x.Column == (int)_tank.Position.x && x.Row == (int)_tank.Position.y);
        }
        foreach (GameObject gobj in GameObject.FindGameObjectsWithTag("Grass"))
        {
            gobjs.Add(gobj);
            GameSettings.Map.Bushes.RemoveAll(x => x.Column == (int)_tank.Position.x && x.Row == (int)_tank.Position.y);
        }
        foreach (GameObject gobj in GameObject.FindGameObjectsWithTag("Water"))
        {
            gobjs.Add(gobj);
            GameSettings.Map.Waters.RemoveAll(x => x.Column == (int)_tank.Position.x && x.Row == (int)_tank.Position.y);
        }
        foreach (GameObject gobj in GameObject.FindGameObjectsWithTag("Player"))
        {
            gobjs.Add(gobj);
            GameSettings.Map.Players.RemoveAll(x => x.Column == (int)_tank.Position.x && x.Row == (int)_tank.Position.y);
        }
        foreach (GameObject gobj in GameObject.FindGameObjectsWithTag("Enemy"))
        {
            gobjs.Add(gobj);
            GameSettings.Map.Enemies.RemoveAll(x => x.Column == (int)_tank.Position.x && x.Row == (int)_tank.Position.y);
        }
        foreach (GameObject gobj in GameObject.FindGameObjectsWithTag("Base"))
        {
            gobjs.Add(gobj);
            GameSettings.Map.Bases.RemoveAll(x => x.Column == (int)_tank.Position.x && x.Row == (int)_tank.Position.y);
        }

        foreach (GameObject prefab in gobjs)
        {
            if (prefab.transform.position == position)
            {
                Destroy(prefab); // Destroy the prefab if its position matches the target position
            }
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
        else if (buildingBlock.Equals(nameof(Water)))
        {
            Instantiate(Water, _tank.Position, Quaternion.identity);
            GameSettings.Map.Waters.Add(new Position((int)_tank.Position.y, (int)_tank.Position.x));
        }
        else if (buildingBlock.Equals(nameof(Bush)))
        {
            Instantiate(Bush, _tank.Position, Quaternion.identity);
            GameSettings.Map.Bushes.Add(new Position((int)_tank.Position.y, (int)_tank.Position.x));
        }
        else if (buildingBlock.Equals(nameof(Enemy)))
        {
            GameObject enemy = Instantiate(Enemy, _tank.Position, Quaternion.identity);
            Destroy(enemy.GetComponent<EnemyController>());
            Destroy(enemy.GetComponent<TankMover>());
            Destroy(enemy.GetComponent<TankFirer>());
            Destroy(enemy.GetComponent<Rigidbody2D>());
            Destroy(enemy.GetComponent<BoxCollider2D>());
            GameSettings.Map.Enemies.Add(new Position((int)_tank.Position.y, (int)_tank.Position.x));
        }
        else if (buildingBlock.Equals(nameof(Player)))
        {
            GameObject player = Instantiate(Player, _tank.Position, Quaternion.identity);
            Destroy(player.GetComponent<TankController>());
            Destroy(player.GetComponent<TankMover>());
            Destroy(player.GetComponent<TankFirer>());
            Destroy(player.GetComponent<Rigidbody2D>());
            Destroy(player.GetComponent<BoxCollider2D>());
            GameSettings.Map.Players.Add(new Position((int)_tank.Position.y, (int)_tank.Position.x));
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