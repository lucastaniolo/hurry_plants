using System;
using UnityEngine;
using System.Collections;
using UnityEngine.Events;

[RequireComponent(typeof(Collider))]
public class ColliderDetection : MonoBehaviour
{
    public UnityAction<Type> OnColliderEnter;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.LogWarning("OnTriggerEnter! : " + other.gameObject.name);
        OnColliderEnter?.Invoke(other.gameObject.GetType());
    }
}
