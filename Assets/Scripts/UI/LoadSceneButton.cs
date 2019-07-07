using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadSceneButton : MonoBehaviour
{
    public string SceneToLoad;

    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(LoadScene);
    }
    private void LoadScene()
    {
        GameManager.ME.NavigatorManager.LoadLevel(SceneToLoad);
    }
}
