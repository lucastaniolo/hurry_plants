using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    public Vector3 Direction { get; private set; }

    public bool ThrowButton { get; private set; }

    public readonly Dictionary<Vector2, float> directions = new Dictionary<Vector2, float>();

    private void Awake()
    {
        directions.Add(Vector2.up, 0);
        directions.Add(Vector2.left, 0);
        directions.Add(Vector2.down, 0);
        directions.Add(Vector2.right, 0);
    }

    private void Update()
    {
        HandleDirection();
        HandleActions();
    }

    private void HandleDirection()
    {
        // UP
        if (Input.GetKey(KeyCode.W))
            directions[Vector2.up] += Time.deltaTime;
        else
            directions[Vector2.up] = 0;

        // LEFT
        if (Input.GetKey(KeyCode.A))
            directions[Vector2.left] += Time.deltaTime;
        else
            directions[Vector2.left] = 0;

        // DOWN
        if (Input.GetKey(KeyCode.S))
            directions[Vector2.down] += Time.deltaTime;
        else
            directions[Vector2.down] = 0;

        // RIGHT
        if (Input.GetKey(KeyCode.D))
            directions[Vector2.right] += Time.deltaTime;
        else
            directions[Vector2.right] = 0;

        var dir = directions.OrderBy(d => d.Value).FirstOrDefault(d => d.Value != 0);

        Direction = dir.Value == 0 ? Vector3.zero : new Vector3(dir.Key.x, 0, dir.Key.y);
    }

    private void HandleActions()
    {
        ThrowButton = Input.GetKeyDown(KeyCode.Space);
    }
}