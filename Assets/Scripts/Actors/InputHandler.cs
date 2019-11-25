using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using GamepadInput;

public class InputHandler : MonoBehaviour
{
    public GamePad.Index gamePadIndex;

    public Vector3 Direction { get; private set; }

    public bool ThrowButton { get; private set; }
    public bool PickMeButton { get; private set; }

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
//        Debug.Log(GamePad.GetAxis(GamePad.Axis.LeftStick, GamePad.Index.Any));

        if (gamePadIndex == GamePad.Index.One)
        {
            HandleDirection();
        }
        else if (gamePadIndex == GamePad.Index.Two)
        {
            HandleDirection2();
        }
        else if (gamePadIndex == GamePad.Index.Three)
        {
            HandleDirection3();
        }
        else
        {
            HandleDirection4();
        }
        
        HandleStick();
        HandleActions();
    }

    private void HandleDirection4()
    {
        ThrowButton = Input.GetKeyDown(KeyCode.Comma);
        
        // UP
        if (Input.GetKey(KeyCode.I))
            directions[Vector2.up] += Time.deltaTime;
        else
            directions[Vector2.up] = 0;

        // LEFT
        if (Input.GetKey(KeyCode.J))
            directions[Vector2.left] += Time.deltaTime;
        else
            directions[Vector2.left] = 0;

        // DOWN
        if (Input.GetKey(KeyCode.K))
            directions[Vector2.down] += Time.deltaTime;
        else
            directions[Vector2.down] = 0;

        // RIGHT
        if (Input.GetKey(KeyCode.L))
            directions[Vector2.right] += Time.deltaTime;
        else
            directions[Vector2.right] = 0;

        var dir = directions.OrderBy(d => d.Value).FirstOrDefault(d => d.Value != 0);

        Direction = dir.Value == 0 ? Vector3.zero : new Vector3(dir.Key.x, 0, dir.Key.y);
    }

    private void HandleDirection3()
    {
        ThrowButton = Input.GetKeyDown(KeyCode.KeypadMinus);
        
        // UP
        if (Input.GetKey(KeyCode.UpArrow))
            directions[Vector2.up] += Time.deltaTime;
        else
            directions[Vector2.up] = 0;

        // LEFT
        if (Input.GetKey(KeyCode.LeftArrow))
            directions[Vector2.left] += Time.deltaTime;
        else
            directions[Vector2.left] = 0;

        // DOWN
        if (Input.GetKey(KeyCode.DownArrow))
            directions[Vector2.down] += Time.deltaTime;
        else
            directions[Vector2.down] = 0;

        // RIGHT
        if (Input.GetKey(KeyCode.RightArrow))
            directions[Vector2.right] += Time.deltaTime;
        else
            directions[Vector2.right] = 0;

        var dir = directions.OrderBy(d => d.Value).FirstOrDefault(d => d.Value != 0);

        Direction = dir.Value == 0 ? Vector3.zero : new Vector3(dir.Key.x, 0, dir.Key.y);
    }

    private void HandleDirection()
    {
        ThrowButton = Input.GetKeyDown(KeyCode.Space);
        
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
    
    private void HandleDirection2()
    {
        ThrowButton = Input.GetKeyDown(KeyCode.Alpha0);
        
        // UP
        if (Input.GetKey(KeyCode.T))
            directions[Vector2.up] += Time.deltaTime;
        else
            directions[Vector2.up] = 0;

        // LEFT
        if (Input.GetKey(KeyCode.F))
            directions[Vector2.left] += Time.deltaTime;
        else
            directions[Vector2.left] = 0;

        // DOWN
        if (Input.GetKey(KeyCode.G))
            directions[Vector2.down] += Time.deltaTime;
        else
            directions[Vector2.down] = 0;

        // RIGHT
        if (Input.GetKey(KeyCode.H))
            directions[Vector2.right] += Time.deltaTime;
        else
            directions[Vector2.right] = 0;

        var dir = directions.OrderBy(d => d.Value).FirstOrDefault(d => d.Value != 0);

        Direction = dir.Value == 0 ? Vector3.zero : new Vector3(dir.Key.x, 0, dir.Key.y);
    }
    
    private void HandleStick()
    {
        var input = GamePad.GetAxis(GamePad.Axis.LeftStick, gamePadIndex);
//        Debug.Log(input + " " + gamePadIndex);

        if (Mathf.Abs(input.x) > Mathf.Abs(input.y))
            input.y = 0;
        else
            input.x = 0;

        Direction = new Vector3(input.x, 0, input.y);
    }

    private void HandleActions()
    {
        ThrowButton = GamePad.GetButtonDown(GamePad.Button.A, gamePadIndex);
        PickMeButton = GamePad.GetButton(GamePad.Button.B, gamePadIndex);
    }
}
