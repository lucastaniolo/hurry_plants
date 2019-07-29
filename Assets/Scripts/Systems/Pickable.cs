using System;
using UnityEngine;
using UnityEngine.Events;

public class Pickable : SimpleStateMachine
{
    [SerializeField] private Collider trigger; //Set via inspector
    [SerializeField] private Collider wall; //Set via inspector

    [HideInInspector] public UnityEvent OnPickableReady = new UnityEvent();
    [HideInInspector] public UnityEvent OnPicked = new UnityEvent();
    [HideInInspector] public UnityEvent OnThrowed = new UnityEvent();
    [HideInInspector] public OnHit OnHit = new OnHit();

    public enum PickableStates { NOT_PICKABLE, IDLE, PICKED, THROWED }

    public Picker Picker;
    public AirMovement AirMovement;


    private Animator animator = null;
    private new Rigidbody rigidbody;

    private void Start()
    {
        currentState = PickableStates.IDLE;
        rigidbody = GetComponent<Rigidbody>();
    }

    private void IDLE_EnterState()
    {
        animator?.SetTrigger("Idle");
    }

    private void PICKED_EnterState()
    {
        animator?.SetBool("IsPicked", true);
        // wall.enabled = false;
        trigger.enabled = false;
        rigidbody.isKinematic = true;
        Physics.IgnoreCollision(trigger, Picker.Collider);
        OnPicked.Invoke();
    }

    private void PICKED_ExitState()
    {
        animator?.SetBool("IsPicked", false);
        // wall.enabled = true;
        trigger.enabled = true;
        rigidbody.isKinematic = false;
        Invoke(nameof(ResetIgnoreCollision), 0.2f);
    }

    private void THROWED_EnterState()
    {
        transform.SetParent(null);
        animator?.SetBool("IsFlying", true);
        transform.position = Picker.ThrowPoint.position;
        OnThrowed.Invoke();
        Picker = null;
    }

    private void THROWED_FixedUpdate()
    {
        AirMovement.Move(transform.forward);
    }

    private void THROWED_ExitState()
    {
        animator?.SetBool("IsFlying", false);
    }

    private void ResetIgnoreCollision()
    {
        Physics.IgnoreCollision(trigger, Picker.Collider, false);
    }

    public bool Pick(Picker picker)
    {
        if (Picker != null &&
            (PickableStates)currentState != PickableStates.IDLE &&
            (PickableStates)currentState != PickableStates.THROWED)
            return false;

        Picker = picker;
        currentState = PickableStates.PICKED;

        return true;
    }

    public void ResolvePick(bool success)
    {
        if (success)
        {
            currentState = PickableStates.PICKED;
        }
        else
        {
            Picker = null;
        }
    }

    public void SetIdle() => currentState = PickableStates.IDLE;
    public void SetThrow() => currentState = PickableStates.THROWED;

    private void OnCollisionEnter(Collision collision)
    {
        // Return false if we can't be picked up at this moment
        if (Picker != null &&
            (PickableStates)currentState != PickableStates.IDLE &&
            (PickableStates)currentState != PickableStates.THROWED)
            return;

        Picker = collision.gameObject.GetComponent<Picker>();

        if (Picker != null)
        {
            Picker.TryPick(this);
        }
        else if ((PickableStates)currentState == PickableStates.THROWED)
        {
            OnHit.Invoke(collision.gameObject);
            currentState = PickableStates.IDLE;
        }
    }
}

[System.Serializable] public class OnHit : UnityEvent<GameObject> { }