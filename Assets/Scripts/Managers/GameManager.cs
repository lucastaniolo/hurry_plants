using System.Collections.Generic;
using System.Linq;
using GamepadInput;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public PickManager PickSystem;
    public NavigatorManager NavigatorManager;

    public UnityEvent OnRoundStart = new UnityEvent();
    public UnityEvent OnRoundFinish = new UnityEvent();
    public UnityEvent OnRoundPause = new UnityEvent();

    public static GameManager ME;

    private InputHandler[] playersInputs;

    private List<Victim> victims = new List<Victim>();
    private int objectiveCounter;

    public bool IsGameOver { get; private set; }

    private void Awake()
    {
        ME = this;
        DontDestroyOnLoad(this);
        playersInputs = FindObjectsOfType<InputHandler>();
        victims = FindObjectsOfType<Victim>().ToList();
    }

    private void Start()
    {
        if (SceneManager.GetActiveScene().name == "StartUp")
            NavigatorManager.LoadMenu();
    }

    private void Update()
    {
        // Reload level
        if (Input.GetKeyDown(KeyCode.Escape) || GamePad.GetButtonDown(GamePad.Button.Start, GamePad.Index.Any))
            NavigatorManager.ReloadLevel();
        
        SwitchControlledPlayer();
    }

    // Debug code
    private void SwitchControlledPlayer()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            playersInputs[0].gamePadIndex = GamePad.Index.One;
            playersInputs[1].gamePadIndex = GamePad.Index.Two;
            playersInputs[2].gamePadIndex = GamePad.Index.Two;
            playersInputs[3].gamePadIndex = GamePad.Index.Two;
        }
        
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            playersInputs[0].gamePadIndex = GamePad.Index.Two;
            playersInputs[1].gamePadIndex = GamePad.Index.One;
            playersInputs[2].gamePadIndex = GamePad.Index.Two;
            playersInputs[3].gamePadIndex = GamePad.Index.Two;
        }
        
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            playersInputs[0].gamePadIndex = GamePad.Index.Two;
            playersInputs[1].gamePadIndex = GamePad.Index.Two;
            playersInputs[2].gamePadIndex = GamePad.Index.One;
            playersInputs[3].gamePadIndex = GamePad.Index.Two;
        }
        
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            playersInputs[0].gamePadIndex = GamePad.Index.Two;
            playersInputs[1].gamePadIndex = GamePad.Index.Two;
            playersInputs[2].gamePadIndex = GamePad.Index.Two;
            playersInputs[3].gamePadIndex = GamePad.Index.One;
        }
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
