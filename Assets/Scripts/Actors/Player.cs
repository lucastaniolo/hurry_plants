using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GamepadInput;

public class Player : MonoBehaviour
{
    public Pickable Pickable;
    public Picker Picker;
    public AirMovement AirMovement;
    public GroundMovement GroundMovement;
    public InputHandler InputHandler;

    private enum State
    {
        IDLE,
        RUNNING,
        FLYING,
        CAPTURED,
    }

    private State state;

    void Start()
    {

    }

    private void Update()
    {
        switch (state)
        {
            case State.IDLE:
                Pickable.SetPickable();
                break;
            case State.RUNNING:
                break;
            case State.FLYING:
                break;
            case State.CAPTURED:
                break;
        }

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
}
