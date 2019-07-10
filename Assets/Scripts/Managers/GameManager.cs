using System.Collections;
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

    private void Awake()
    {
        ME = this;
        DontDestroyOnLoad(this);
    }

    private void Start()
    {
        if (SceneManager.GetActiveScene().name == "StartUp")
            NavigatorManager.LoadMenu();
    }

    private void Update()
    {
        // Reload level
        if (Input.GetKeyDown(KeyCode.Escape))
            NavigatorManager.ReloadLevel();
    }
}
