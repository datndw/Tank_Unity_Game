using System;
using System.Collections;
using System.Collections.Generic;
using Entities;
using Enumerations;
using UnityEngine;

public class BuilderDasher : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }


    public Vector3 Dash(Direction direction)
    {
        var currentPos = gameObject.transform.position;
        switch (direction)
        {
            case Direction.Down:
                currentPos.y -= 1;
                break;
            case Direction.Left:
                currentPos.x -= 1;
                break;
            case Direction.Right:
                currentPos.x += 1;
                break;
            case Direction.Up:
                currentPos.y += 1;
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(direction), direction, null);
        }

        gameObject.transform.position = currentPos;
        return currentPos;
    }
}