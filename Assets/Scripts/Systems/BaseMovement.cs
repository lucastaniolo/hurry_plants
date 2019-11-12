using UnityEngine;

public abstract class BaseMovement : MonoBehaviour
{
    [SerializeField] protected float baseSpeed;
    [SerializeField] protected Rigidbody rigidbody;
    [SerializeField] protected GameObject trailFx;

    private void Awake()
    {
        SetTrail(false);
    }

    public virtual void Move(Vector3 direction)
    {
        rigidbody.MovePosition(rigidbody.position + baseSpeed * Time.deltaTime * direction.normalized);
    }
    
    public virtual void Move(Vector3 direction, float multiplier)
    {
        rigidbody.MovePosition(rigidbody.position + baseSpeed * Time.deltaTime * multiplier * direction.normalized);
    }
    
    protected void Rotate(Vector3 input)
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

    public void SetTrail(bool active)
    {
        if (trailFx != null)
            trailFx.SetActive(active);
    }
}