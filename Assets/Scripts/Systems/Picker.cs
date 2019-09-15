using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Picker : MonoBehaviour
{
    public Transform PickedPoint;
    public Transform ThrowPoint;
    public Pickable Pickable;
    private Animator Animator = null;
    public Collider Collider { get; private set; }

    private void Start()
    {
        Collider = GetComponent<Collider>();
    }

    public void TryPick(Pickable pickable)
    {
        if (Pickable != null) 
        {
            pickable.ResolvePick(false);
            return;
        }

        pickable.ResolvePick(true);

        Pickable = pickable;
        Pickable.OnHit.AddListener(ResetCollision);
        Pickable.transform.SetParent(PickedPoint);
        Pickable.transform.rotation = PickedPoint.rotation;
        Pickable.transform.localPosition = Vector3.zero;
    }

    private void ResetCollision(Pickable throwedPickable, GameObject pickable)
    {
        Physics.IgnoreCollision(Collider, throwedPickable.Collider, false);
    }

    public void Throw()
    {
        if (Pickable == null) return;

        Animator?.SetTrigger("Throw");
        Pickable.SetThrow();
        Pickable = null;
    }
}
