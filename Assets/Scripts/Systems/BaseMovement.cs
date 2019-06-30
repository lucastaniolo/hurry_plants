﻿using UnityEngine;

public abstract class BaseMovement : MonoBehaviour
{
    [SerializeField] protected float baseSpeed;
    [SerializeField] protected Rigidbody rigidbody;

    public abstract void Move(Vector3 direction, float speedMultiplier = 1f);

    public enum Direction { LEFT, RIGHT, UP, DOWN }
    protected Direction direction;



    public void Rotate(Vector3 input)
    {
        var angle = 0f;

        if (input.x > input.z)
        {
            if (input.x > 0)
                angle = 90f;
            else if (input.x < 0)
                angle = -90f;
            else if (input.z > 0)
                angle = 0;
            else if (input.z < 0)
                angle = 180f;
        }
        else
        {
            if (input.z > 0)
                angle = 0;
            else if (input.z < 0)
                angle = 180f;
            else if (input.x > 0)
                angle = 90f;
            else if (input.x < 0)
                angle = -90f;
        }

        rigidbody.transform.eulerAngles = new Vector3(0, angle, 0);
    }
}