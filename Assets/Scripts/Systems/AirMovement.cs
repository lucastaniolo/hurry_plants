using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirMovement : BaseMovement
{
    public override void Move(Vector3 direction, float speedMultiplier = 3f)
    {
        rigidbody.MovePosition(rigidbody.position + direction * baseSpeed * Time.deltaTime * speedMultiplier);
    }
}
