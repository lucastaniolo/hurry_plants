using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PickManager : MonoBehaviour
{
    public List<Pickable> Pickables = new List<Pickable>();

    private void OnEnable()
    {
        Pickables = FindObjectsOfType<Pickable>().ToList();
    }

    private void OnDisable()
    {
        Pickables = null;
    }
}
