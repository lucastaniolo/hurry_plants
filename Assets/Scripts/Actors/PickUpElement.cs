using UnityEngine;

public class PickUpElement<O> : MonoBehaviour where O : IObjective
{
    [SerializeField] private Pickable pickable;
    [SerializeField] private GameObject hitFx;
    [SerializeField] private GameObject pickFx;
    [SerializeField] private GameObject throwFx;
    [SerializeField] private Respawner respawner;

    private void Start()
    {
        pickable = GetComponent<Pickable>();
        pickable.OnHit.AddListener(OnHit);
        pickable.OnPicked.AddListener(OnPick);
        pickable.OnThrowed.AddListener(OnThrow);
    }

    private void OnThrow()
    {
        if (throwFx != null)
            Instantiate(throwFx, transform.position, Quaternion.identity);
    }

    private void OnPick()
    {
        if (pickFx != null)
            Instantiate(pickFx, transform.position, Quaternion.identity);
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