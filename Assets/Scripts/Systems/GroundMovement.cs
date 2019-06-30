using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundMovement : BaseMovement
{
    public override void Move(Vector3 direction, float speedMultiplier = 1f)
    {
        Rotate(direction);
        rigidbody.MovePosition(rigidbody.position + direction * baseSpeed * Time.deltaTime * speedMultiplier);
    }
}
