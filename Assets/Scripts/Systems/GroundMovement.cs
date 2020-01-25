using UnityEngine;

public class GroundMovement : BaseMovement
{
    public bool InsideWaterStream { get; private set; }
    
    public override void Move(Vector3 direction)
    {
        Rotate(direction);
        base.Move(direction);
    }
    
    public override void Move(Vector3 direction, float multiplier)
    {
        Rotate(direction);
        base.Move(direction, multiplier);
    }

    public void EnterWaterStream() => InsideWaterStream = true;
    public void LeaveWaterStream() => InsideWaterStream = false;
}