using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Pickable : SimpleStateMachine
{
    [SerializeField] private Collider collider; //Set via inspector

    [HideInInspector] public UnityEvent OnPickableReady = new UnityEvent();
    [HideInInspector] public UnityEvent OnPicked = new UnityEvent();
    [HideInInspector] public UnityEvent OnThrowed = new UnityEvent();

    private enum PickableStates { NOT_PICKABLE, PICKABLE, PICKED, THROWED }

    private void PICKABLE_EnterState()
    {
        OnPicked.Invoke();
    }

    public void SetPickable(bool canBePicked)
    {
        currentState = canBePicked ? PickableStates.PICKABLE : PickableStates.NOT_PICKABLE;

        OnPickableReady.Invoke();
    }

    public void Pick()
    {

    }
}
