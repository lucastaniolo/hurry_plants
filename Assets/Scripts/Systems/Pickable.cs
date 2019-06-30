using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Pickable : MonoBehaviour
{
    private bool pickable;

    [SerializeField] private Collider collider;

    [HideInInspector] public UnityEvent OnPickableReady = new UnityEvent();
    [HideInInspector] public UnityEvent OnPicked = new UnityEvent();
    [HideInInspector] public UnityEvent OnThrowed = new UnityEvent();

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void SetPickable(bool canBePicked = true)
    {
        pickable = canBePicked;
        OnPickableReady.Invoke();
    }

    public void Picked()
    {
        OnPicked.Invoke();
    }
}
