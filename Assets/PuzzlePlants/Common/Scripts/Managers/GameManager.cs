using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private NavigatorManager navigator;

    public static GameManager ME;

    private List<Victim> victims = new List<Victim>();
    private int objectiveCounter;
    
    public bool IsGameOver { get; private set; }

    private void Awake()
    {
        if (ME != null)
            Destroy(this);
        
        ME = this;
    }

    private void Start()
    {
        navigator.OnLevelLoaded += Initiate;
    }

    private void Initiate()
    {
        victims = FindObjectsOfType<Victim>().ToList();
    }
    
    public void CountObjective()
    {
        objectiveCounter++;

        if (objectiveCounter >= victims.Count)
        {
            IsGameOver = true;
        }
    }
}
