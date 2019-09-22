using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Picker : MonoBehaviour
{
    public Transform PickedPoint;
    public Transform ThrowPoint;
    private Pickable pickable;
    private Animator animator = null;
    public Collider Collider { get; private set; }

    private void Start()
    {
        Collider = GetComponent<Collider>();
    }

    public void TryPick(Pickable target)
    {
        if (pickable != null) 
        {
            target.ResolvePick(false);
            return;
        }

        target.ResolvePick(true);

        pickable = target;
        pickable.OnHit.AddListener(ResetCollision);
        pickable.transform.SetParent(PickedPoint);
        pickable.transform.rotation = PickedPoint.rotation;
        pickable.transform.localPosition = Vector3.zero;
    }

    private void ResetCollision(Pickable thrownPickable, GameObject pickable)
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
}
