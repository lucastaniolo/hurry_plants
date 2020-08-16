using System;
using UnityEngine;

public class PickUpElement<O> : MonoBehaviour where O : IObjective
{
    [SerializeField] private Pickable pickable;
    [SerializeField] private GameObject hitFx;
    [SerializeField] private GameObject pickFx;
    [SerializeField] private GameObject throwFx;
    [SerializeField] private Respawner respawner;

    protected GameObject HitFx => hitFx;
    protected Respawner Respawner => respawner;
    protected Pickable Pickable => pickable;
    
    protected virtual KillType KillType { get; }
    
    private void Awake()
    {
        pickable = GetComponent<Pickable>();
        pickable.OnHit.AddListener(OnHit);
        pickable.OnPicked.AddListener(OnPick);
        pickable.OnThrowed.AddListener(OnThrow);
        pickable.OnReleased.AddListener(OnRelease);
    }

    protected virtual void OnEnable()
    {
        pickable.ResetKinematic();
    }

    private void OnRelease()
    {
        respawner.Register();
    }

    private void OnThrow()
    {
        if (throwFx != null)
            Instantiate(throwFx, transform.position, Quaternion.identity);
    }

    protected virtual void OnPick()
    {
        if (pickFx != null)
            Instantiate(pickFx, transform.position, Quaternion.identity);
    }

    protected virtual void OnHit(Pickable throwedPickable, GameObject hitObject)
    {
        Instantiate(hitFx, transform.position, Quaternion.identity);

        if (hitObject.TryGetComponent<O>(out var target))
        {
            target.ObjectiveHit();
            Destroy(gameObject);
            Debug.Log($"{gameObject.name} hit objective {target}!");
            return;
        }
        
        respawner.Register();

        if (hitObject.TryGetComponent<Player>(out var player))
        {
            player.KillBy(KillType);
        }
        else if (hitObject.TryGetComponent<Respawner>(out var targetRespawn))
        {
            Debug.Log($"{gameObject.name} hit non objective {targetRespawn}");
            targetRespawn.Register();
        }
    }
}