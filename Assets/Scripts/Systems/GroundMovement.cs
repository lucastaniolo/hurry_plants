using UnityEngine;

public class GroundMovement : BaseMovement
{
    public override void Move(Vector3 direction)
    {
        Rotate(direction);
        base.Move(direction);
    }
}
