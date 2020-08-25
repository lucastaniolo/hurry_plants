using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody))]
public class Picker : MonoBehaviour
{
    public Transform PickedPoint;
    public Transform ThrowPoint;
    private Pickable pickable;
    private Animator animator = null;
    public Collider Collider { get; private set; }

    public bool IsBusy => pickable != null || Unavaiable;
    public bool Unavaiable { get; set; }

    [HideInInspector] public UnityEvent OnPickerDie = new UnityEvent();
    [HideInInspector] public UnityEvent OnPick = new UnityEvent();
    
    private void Start()
    {
        Collider = GetComponent<Collider>();
        OnPickerDie.AddListener(OnDie);
    }

    private void OnDie()
    {
        if (pickable != null)
        {
//            pickable.OnHit.Invoke(pickable, gameObject);
            
            ResetCollision(pickable);
        }
    }

    public void TryPick(Pickable target)
    {
        if (pickable != null) 
        {
            //target.ResolvePick(null);
            return;
        }

        target.ResolvePick(this);

        pickable = target;
        pickable.OnThrowFinished = ResetCollision;
        pickable.transform.SetParent(PickedPoint);
        pickable.transform.rotation = PickedPoint.rotation;
        pickable.transform.localPosition = Vector3.zero;
        OnPick.Invoke();
    }

    private void ResetCollision(Pickable thrownPickable)
    {
        Physics.IgnoreCollision(Collider, thrownPickable.Collider, false);
    }

    public void Throw()
    {
        if (pickable == null) return;

        animator?.SetTrigger("Throw");
        pickable.SetThrow();
        pickable = null;
    }

    public void Release()
    {
        if (pickable == null) return;
        
        Physics.IgnoreCollision(Collider, pickable.Collider, false);
        pickable = null;
    }
}
