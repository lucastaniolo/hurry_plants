using UnityEngine;

// TODO: water stream
// Create system that influence GroundMovement speed
// Behaviour is similar to a treadmill
// Inspector should have a velocity property, direction is defined by object rotation

public class GroundMovement : BaseMovement
{
    public override void Move(Vector3 direction)
    {
        Rotate(direction);
        base.Move(direction);
    }
}
