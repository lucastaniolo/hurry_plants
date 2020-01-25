using UnityEngine;
using UnityEngine.Serialization;

public abstract class BaseMovement : MonoBehaviour
{
    [SerializeField] protected float baseSpeed;
    [FormerlySerializedAs("rigidbody")] [SerializeField] protected Rigidbody body;
    [SerializeField] protected GameObject trailFx;
    
    private void Awake()
    {
        SetTrail(false);
    }

    public virtual void Move(Vector3 direction)
    {
        body.MovePosition(body.position + baseSpeed * Time.deltaTime * direction.normalized);
    }
    
    public virtual void Move(Vector3 direction, float multiplier)
    {
        body.MovePosition(body.position + baseSpeed * Time.deltaTime * multiplier * direction.normalized);
    }
    
    public void Drag(Vector3 direction, float speed)
    {
        body.MovePosition(body.position + speed * Time.deltaTime * direction.normalized);
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

        body.transform.eulerAngles = new Vector3(0, angle, 0);
    }

    public void SetTrail(bool active)
    {
        if (trailFx != null)
            trailFx.SetActive(active);
    }
}