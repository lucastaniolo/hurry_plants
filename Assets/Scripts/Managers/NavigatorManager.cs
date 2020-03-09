using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NavigatorManager : MonoBehaviour
{
    [SerializeField] private List<SceneReference> levels = new List<SceneReference>();
    [SerializeField] private RectTransform levelsContainer;
    [SerializeField] private LevelButton levelButtonPrefab;
    [SerializeField] private GameObject levelSelection;
    [SerializeField] private Button pauseButton;

    public event Action OnLevelLoaded;

    private SceneReference currentLevel;
    
    public void Awake()
    {
        foreach (var level in levels)
        {
            var levelButton = Instantiate(levelButtonPrefab, levelsContainer);
            levelButton.SetLevel(level);
            levelButton.ClickLevelEvent += LoadLevel;
        }
        
        pauseButton.onClick.AddListener(TogglePauseMenu);
    }

    private void LoadLevel(SceneReference level) => StartCoroutine(LoadLevelRoutine(level));

    private IEnumerator LoadLevelRoutine(SceneReference level)
    {
        var activeLevel = levels.FirstOrDefault(l => l.ScenePath == currentLevel?.ScenePath);
        if (activeLevel != null)
        {
            var unloading = SceneManager.UnloadSceneAsync(activeLevel);
            yield return new WaitUntil(() => unloading.isDone);
        }

        var loading = SceneManager.LoadSceneAsync(level, LoadSceneMode.Additive);
        yield return new WaitUntil(() => loading.isDone);
        
        currentLevel = level;
        levelSelection.SetActive(false);

        OnLevelLoaded?.Invoke();
    }
    
    public void ReloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            TogglePauseMenu();
        
        if (Input.GetKeyDown(KeyCode.Return))
            ReloadLevel();
    }

    private void TogglePauseMenu()
    {
        var isOn = levelSelection.activeInHierarchy;
        levelSelection.SetActive(!isOn);
    }
}
