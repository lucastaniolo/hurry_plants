using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.InputSystem.InputAction;

public class InputHandler : MonoBehaviour
{
    public Vector3 Direction { get; private set; }

    public bool ThrowButton { get; private set; }
    public bool PickMeButton { get; private set; }

    public readonly Dictionary<Vector2, float> directions = new Dictionary<Vector2, float>();

    public void OnMove(CallbackContext context)
    {
        var input = context.ReadValue<Vector2>();
        
        if (Mathf.Abs(input.x) > Mathf.Abs(input.y))
            input.y = 0;
        else
            input.x = 0;

        Direction = new Vector3(input.x, 0, input.y);
    }

    public void OnThrow(CallbackContext context)
    {
        ThrowButton = context.phase == InputActionPhase.Performed;
    }

    public void OnPickMe(CallbackContext context)
    {
        PickMeButton = context.phase == InputActionPhase.Performed;
    }
  
//    private void HandleDirection()
//    {
//        // UP
//        if (Input.GetKey(KeyCode.T))
//            directions[Vector2.up] += Time.deltaTime;
//        else
//            directions[Vector2.up] = 0;
//
//        // LEFT
//        if (Input.GetKey(KeyCode.F))
//            directions[Vector2.left] += Time.deltaTime;
//        else
//            directions[Vector2.left] = 0;
//
//        // DOWN
//        if (Input.GetKey(KeyCode.G))
//            directions[Vector2.down] += Time.deltaTime;
//        else
//            directions[Vector2.down] = 0;
//
//        // RIGHT
//        if (Input.GetKey(KeyCode.H))
//            directions[Vector2.right] += Time.deltaTime;
//        else
//            directions[Vector2.right] = 0;
//
//        var dir = directions.OrderBy(d => d.Value).FirstOrDefault(d => d.Value != 0);
//
//        Direction = dir.Value == 0 ? Vector3.zero : new Vector3(dir.Key.x, 0, dir.Key.y);
//    }
    
//    private void HandleStick()
//    {
//        var input = GamePad.GetAxis(GamePad.Axis.LeftStick, gamePadIndex);
//
//        if (Mathf.Abs(input.x) > Mathf.Abs(input.y))
//            input.y = 0;
//        else
//            input.x = 0;
//
//        Direction = new Vector3(input.x, 0, input.y);
//    }
}
