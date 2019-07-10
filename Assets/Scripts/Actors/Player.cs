using UnityEngine;

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
        Pickable.OnPicked.AddListener(() => currentState = PlayerStates.CAPTURED);
        Pickable.OnThrowed.AddListener(() => currentState = PlayerStates.FLYING);

        currentState = PlayerStates.IDLE;
    }

    protected override void EarlyGlobalSuperUpdate()
    {
        if (InputHandler.ThrowButton)
            Picker.Throw();
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
        Pickable.SetIdle();
    }

    private void IDLE_Update()
    {
        if (InputHandler.Direction != Vector3.zero)
            currentState = PlayerStates.RUNNING;
    }

    private void IDLE_ExitState()
    {
        Pickable.SetIdle();
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

    private void OnDrawGizmos()
    {
        var from = transform.position + Vector3.up;
        var to = from + transform.forward * 1.5f;
        Gizmos.DrawLine(from, to);
    }
}
