using System;
using UnityEngine;
using System.Collections;

public class Killer : MonoBehaviour
{
    [SerializeField] public ColliderDetection colliderDetection;

    // Use this for initialization
    void Start()
    {
        colliderDetection.OnColliderEnter = OnColliderEnter;
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    private void OnColliderEnter(Type type)
    {
        Debug.LogWarning("Killer Triggered! : " + type.Name);
    }
}
