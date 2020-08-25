using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelButton : MonoBehaviour
{
    [SerializeField] private Button button;
    [SerializeField] private TextMeshProUGUI label;

    private SceneReference level;

    public event Action<SceneReference> ClickLevelEvent; 
    
    public void SetLevel(SceneReference level)
    {
        this.level = level;
        label.SetText(level.ScenePath.Split('/', '.')[3]);
        button.onClick.AddListener(LoadLevel);
    }

    private void LoadLevel()
    {
        ClickLevelEvent?.Invoke(level);
    }
}