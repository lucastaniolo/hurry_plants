using UnityEngine;

public class SelfDestruct : MonoBehaviour
{
    public float Timer = 1f;
    private void Start() => Destroy(gameObject, Timer);
}
