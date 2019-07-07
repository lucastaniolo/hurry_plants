using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GamepadInput;

public class Player : SimpleStateMachine
{
    public Pickable Pickable;
    public Picker Picker;
    public AirMovement AirMovement;
    public GroundMovement GroundMovement;
    public InputHandler InputHandler;

    private enum PlayerStates { IDLE, RUNNING, FLYING, CAPTURED }

    void Start()
    {

    }

    protected override void EarlyGlobalSuperUpdate()
    {

    }

    protected override void LateGlobalSuperUpdate()
    {

    }

    private void RUNNING_FixedUpdate()
    {
        if (InputHandler.Direction != Vector3.zero) //Comment this to enable always moving mechanic
            GroundMovement.Move(InputHandler.Direction);
        else
            currentState = PlayerStates.IDLE;
    }

    private void IDLE_EnterState()
    {
        Pickable.SetPickable(true);
    }

    private void IDLE_ExitState()
    {
        Pickable.SetPickable(false);
    }

    private void CAPTURED_EnterState()
    {

    }

    private void CAPTURED_UpdateState()
    {

    }

    private void CAPTURED_ExitState()
    {

    }

    private void FixedUpdate()
    {
        //var direction = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        //GroundMovement.Move(direction);

        if (InputHandler.Direction != Vector3.zero) //Comment this to enable always moving mechanic
            GroundMovement.Move(InputHandler.Direction);
    }

    private void OnDrawGizmos()
    {
        var from = transform.position + Vector3.up;
        var to = from + transform.forward * 1.5f;
        Gizmos.DrawLine(from, to);
    }

    private void OnPicked()
    {
        currentState = PlayerStates.CAPTURED;
    }
}
