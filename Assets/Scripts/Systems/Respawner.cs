using UnityEngine;
using UnityEngine.Events;

public class Respawner : MonoBehaviour
{ 
    [HideInInspector] public UnityEvent OnSpawn = new UnityEvent();
    private Vector3 startPosition;
    private Quaternion startRotation;

    [SerializeField] private float timeToSpawn;
    [SerializeField] private GameObject spawnFx;
    [SerializeField] private GameObject registerSpawnFx;
    public bool IsRespawning { get; set; }

    private void Start()
    {
        startPosition = transform.position;
        startRotation = transform.rotation;
    }

    public void Respawn()
    {
        IsRespawning = false;
        transform.position = startPosition;
        transform.rotation = startRotation;
        gameObject.SetActive(true);
        Instantiate(spawnFx, startPosition, Quaternion.identity);
    }

    public void Register()
    {
        Debug.Log("Register Spawn");
        gameObject.SetActive(false);
        Instantiate(registerSpawnFx, startPosition, Quaternion.identity);
        SpawnManager.ME.RegisterSpawn(this, timeToSpawn);
    }
}