using System;
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
            RegisterGroundMovement(groundMovement);
    }

    private void OnTriggerExit(Collider other)
    {
        var groundExiting = groundMovements.FirstOrDefault(g => g.gameObject == other.gameObject);
        if (groundExiting != null)
            ReleaseGroundMovement(groundExiting);
    }

    private void FixedUpdate()
    {
        if (groundMovements == null || groundMovements.Count == 0) return;

        GroundMovement groundExiting = null;
        foreach (var groundMovement in groundMovements)
        {
            groundMovement.Drag(transform.forward, velocity);

            if (!groundMovement.gameObject.activeInHierarchy || !groundMovement.InsideWaterStream)
                groundExiting = groundMovement;
        }
        
        if (groundExiting != null)
            ReleaseGroundMovement(groundExiting);
    }

    private void RegisterGroundMovement(GroundMovement groundMovement)
    {
        groundMovements.Add(groundMovement);
        groundMovement.EnterWaterStream();
    }
    
    public void ReleaseGroundMovement(GroundMovement groundMovement)
    {
        groundMovement.LeaveWaterStream();
        groundMovements.Remove(groundMovement);
    }
}