using UnityEngine;
using UnityEngine.Events;

public class Respawner : MonoBehaviour
{ 
    [HideInInspector] public UnityEvent OnSpawn = new UnityEvent();
    private Vector3 startPosition;

    [SerializeField] private float timeToSpawn;
    [SerializeField] private GameObject spawnFx;
    [SerializeField] private GameObject registerSpawnFx;

    private void Start()
    {
        startPosition = transform.position;
    }

    public void Respawn()
    {
        gameObject.SetActive(true);
        Instantiate(spawnFx, startPosition, Quaternion.identity);
    }

    public void Register()
    {
        gameObject.SetActive(false);
        Instantiate(registerSpawnFx, startPosition, Quaternion.identity);
        SpawnManager.ME.RegisterSpawn(this, timeToSpawn);
    }
}