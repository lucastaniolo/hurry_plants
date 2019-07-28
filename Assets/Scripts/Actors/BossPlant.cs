using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossPlant : MonoBehaviour, IObjective
{
    [SerializeField] private Animator animator;

    public void ObjectiveHit()
    {
        animator.SetTrigger("Eat");
    }
}