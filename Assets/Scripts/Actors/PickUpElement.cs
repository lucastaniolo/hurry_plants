using UnityEngine;

public class PickUpElement<O> : MonoBehaviour where O : IObjective
{
    [SerializeField] private Pickable pickable;
    [SerializeField] private GameObject hitFx;
    [SerializeField] private Respawner respawner;

    private void Start()
    {
        pickable = GetComponent<Pickable>();
        pickable.OnHit.AddListener(OnHit);

        var elementt = GetComponent<PickUpElement<O>>();
    }

    protected virtual void OnHit(Pickable throwedPickable, GameObject hitObject)
    {
        Instantiate(hitFx, transform.position, Quaternion.identity);

        var target = hitObject.GetComponent<O>();

        if (target != null)
        {
            target.ObjectiveHit();
            Destroy(gameObject);
            Debug.Log("Destroy on Hit");
            return;
        }

        respawner.Register();

        var targetRespawn = hitObject.GetComponent<Respawner>();

        if (targetRespawn != null)
        {
            targetRespawn.Register();
        }
    }
}