using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RoundTimer : MonoBehaviour
{
//    [SerializeField] private 

    private TextMeshProUGUI timerLabel;
    private float counter;

    [SerializeField] private TextMeshProUGUI lapLabel;
    
    private List<int> laps = new List<int>();

    private int TotalLapCount => PlayerPrefs.GetInt(SceneManager.GetActiveScene().name + "lapCount");
    
    private void Start()
    {
        timerLabel = GetComponent<TextMeshProUGUI>();

        for (var i = 0; i < TotalLapCount; i++)
        {
            laps.Add(PlayerPrefs.GetInt(SceneManager.GetActiveScene().name + "lap" + i));
        }
        
        lapLabel.text = laps.Sum().ToString();
    }

    private void Update()
    {
        if (GameManager.ME.IsGameOver)
        {
            if (!laps.Contains((int) counter))
            {
                laps.Add((int)counter);
                lapLabel.text = laps.Sum().ToString();
            }
            
            return;
        }
        
        counter += Time.deltaTime;
        timerLabel.text = ((int)counter).ToString();
    }

    private void OnDestroy()
    {
        for (var i = 0; i < laps.Count; i++)
        {
            PlayerPrefs.SetInt(SceneManager.GetActiveScene().name + "lap" + i, laps[i]);
        }
        
        PlayerPrefs.SetInt(SceneManager.GetActiveScene().name + "lapCount", laps.Count);
    }

}
