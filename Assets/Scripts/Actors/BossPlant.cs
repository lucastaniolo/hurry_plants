using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossPlant : MonoBehaviour, IObjective
{
    [SerializeField] private Animator animator;
    [SerializeField] public Picker picker;

    private enum BossStates { Idle, Eat, Dead}

    public void ObjectiveHit()
    {
        animator.SetTrigger("EatNpc");
    }

    private void UpdateState(BossStates state)
    {
        switch (state)
        {
            case BossStates.Idle:
                break;
            case BossStates.Eat:
                break;
            case BossStates.Dead:
                break;

        }
    }

}