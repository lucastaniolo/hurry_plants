using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class WaterStream : MonoBehaviour
{
    [SerializeField] private float velocity;
    private GroundMovement groundMovement;

    private void OnTriggerEnter(Collider other) => groundMovement = other.GetComponent<GroundMovement>();
    private void OnTriggerExit(Collider other) => groundMovement = null;

    private void FixedUpdate()
    {
        if (groundMovement == null) return;
        groundMovement.Move(transform.forward * velocity);
    }
}