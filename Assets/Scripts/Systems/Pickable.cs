using UnityEngine;
using UnityEngine.Events;

public class Pickable : SimpleStateMachine
{
    [SerializeField] private Collider collider; //Set via inspector

    [HideInInspector] public UnityEvent OnPickableReady = new UnityEvent();
    [HideInInspector] public UnityEvent OnPicked = new UnityEvent();
    [HideInInspector] public UnityEvent OnThrowed = new UnityEvent();

    public enum PickableStates { NOT_PICKABLE, IDLE, PICKED, THROWED }

    public Picker Picker;
    public AirMovement AirMovement;

    private Animator animator = null;

    private void Start()
    {
        currentState = PickableStates.IDLE;
    }

    private void IDLE_EnterState()
    {
        animator?.SetTrigger("Idle");
    }

    private void PICKED_EnterState()
    {
        animator?.SetBool("IsPicked", true);
        OnPicked.Invoke();
    }

    private void PICKED_ExitState()
    {
        animator?.SetBool("IsPicked", false);
    }

    private void THROWED_EnterState()
    {
        Picker = null;
        animator?.SetTrigger("Throw");
        OnThrowed.Invoke();
    }

    private void THROWED_FixedUpdate()
    {
        AirMovement.Move(transform.forward);
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

    public void SetIdle() => currentState = PickableStates.IDLE;
    public void SetThrow() => currentState = PickableStates.THROWED;

}
