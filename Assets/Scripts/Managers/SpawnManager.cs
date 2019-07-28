using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public static SpawnManager ME;

    private void Awake()
    {
        ME = this;
    }

    public void RegisterSpawn(Respawner respawner, float timer)
    {
        StartCoroutine(InternalSpawn(respawner, timer));
    }

    private IEnumerator InternalSpawn(Respawner respawner, float timer)
    {
        yield return new WaitForSeconds(timer);
        respawner.Respawn();
        Debug.Log("Respawn");
    }
}
