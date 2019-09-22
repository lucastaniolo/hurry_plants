using UnityEngine;
using UnityEngine.Events;

public class Pickable : SimpleStateMachine
{
    [SerializeField] private Collider trigger;
    [SerializeField] private AirMovement airMovement;

    [HideInInspector] public UnityEvent OnPicked = new UnityEvent();
    [HideInInspector] public UnityEvent OnThrowed = new UnityEvent();
    [HideInInspector] public OnHit OnHit = new OnHit();

    private enum PickableStates { Idle, Picked, Thrown }
    private Picker picker;

    public Collider Collider => trigger;
    
    private Animator animator = null;
    private new Rigidbody rigidbody;

    private void Start()
    {
        currentState = PickableStates.Idle;
        rigidbody = GetComponent<Rigidbody>();
    }

    private void Idle_EnterState()
    {
        animator?.SetTrigger("Idle");
    }

    private void Picked_EnterState()
    {
        animator?.SetBool("IsPicked", true);
        // wall.enabled = false;
        trigger.enabled = false;
        rigidbody.isKinematic = true;
        Physics.IgnoreCollision(trigger, picker.Collider);
        OnPicked.Invoke();
    }

    private void Picked_ExitState()
    {
        animator?.SetBool("IsPicked", false);
        // wall.enabled = true;
        trigger.enabled = true;
        rigidbody.isKinematic = false;
    }

    private void Thrown_EnterState()
    {
        transform.SetParent(null);
        animator?.SetBool("IsFlying", true);
        transform.position = picker.ThrowPoint.position;
        OnThrowed.Invoke();
        picker = null;
    }

    private void Thrown_FixedUpdate()
    {
        airMovement.Move(transform.forward);
    }

    private void Thrown_ExitState()
    {
        animator?.SetBool("IsFlying", false);
    }

    public bool Pick(Picker picker)
    {
        if (this.picker != null &&
            (PickableStates)currentState != PickableStates.Idle &&
            (PickableStates)currentState != PickableStates.Thrown)
            return false;

        this.picker = picker;
        currentState = PickableStates.Picked;

        return true;
    }

    public void ResolvePick(bool success)
    {
        if (success)
        {
            currentState = PickableStates.Picked;
        }
        else
        {
            picker = null;
        }
    }

    public void SetIdle() => currentState = PickableStates.Idle;
    public void SetThrow() => currentState = PickableStates.Thrown;

    private void OnCollisionEnter(Collision collision)
    {
        // Return false if we can't be picked up at this moment
        if (picker != null &&
            (PickableStates)currentState != PickableStates.Idle &&
            (PickableStates)currentState != PickableStates.Thrown)
            return;
        
        picker = collision.gameObject.GetComponent<Picker>();

        if (picker != null)
        {
            picker.TryPick(this);
        }
        else if ((PickableStates)currentState == PickableStates.Thrown)
        {
            OnHit.Invoke(this, collision.gameObject);
            currentState = PickableStates.Idle;
        }
    }
}

[System.Serializable] public class OnHit : UnityEvent<Pickable, GameObject> { }