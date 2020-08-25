using UnityEngine;

public class Crate : MonoBehaviour, IObjective
{
    [SerializeField] private GameObject destroyFx;

    public void ObjectiveHit()
    {
        Instantiate(destroyFx, transform.position, Quaternion.identity);
        gameObject.SetActive(false);
    }
}