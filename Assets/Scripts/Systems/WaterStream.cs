using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class WaterStream : MonoBehaviour
{
    [SerializeField] private float velocity;
    [SerializeField] private float counterVelocity;
    private readonly List<GroundMovement> groundMovements = new List<GroundMovement>();

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<GroundMovement>(out var groundMovement))
            groundMovements.Add(groundMovement);
    }

    private void OnTriggerExit(Collider other)
    {
        var groundExiting = groundMovements.FirstOrDefault(g => g.gameObject == other.gameObject);
        if (groundExiting != null)
            groundMovements.Remove(groundExiting);
    }

    private void FixedUpdate()
    {
        if (groundMovements == null || groundMovements.Count == 0) return;

        GroundMovement groundExiting = null;
        foreach (var groundMovement in groundMovements)
        {
            if (transform.forward == groundMovement.transform.forward)
                groundMovement.Move(transform.forward, velocity);
            else
                groundMovement.Move(transform.forward, counterVelocity);

            if (!groundMovement.gameObject.activeInHierarchy)
                groundExiting = groundMovement;
        }
        
        if (groundExiting != null)
            groundMovements.Remove(groundExiting);
    }
}