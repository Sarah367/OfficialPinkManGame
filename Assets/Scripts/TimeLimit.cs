using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TimeLimit : MonoBehaviour
{
    [SerializeField] private float timeLimit = 2f; // 10 minutes
    [SerializeField] public Text timerText;

    private float timeRemaining;
    private bool gameEnding = false;
    void Start()
    {
        timeRemaining = timeLimit;
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameEnding) 
        {
            timeRemaining -= Time.deltaTime;
            if (timeRemaining <= 0)
            {
                timeRemaining = 0;
                LoseSceneTrigger();
            }
            UpdateUI();
        }
    }

    void UpdateUI()
    {
        int minutes = Mathf.FloorToInt(timeRemaining / 60);
        int seconds = Mathf.FloorToInt(timeRemaining % 60);
        timerText.text = $"{minutes:00}:{seconds:00}";
    }

    void PauseTime()
    {
        gameEnding = true;
    }
    public void TimerReset()
    {
        timeRemaining = timeLimit;
        UpdateUI();
    }
    void ResumeTimer()
    {
        gameEnding = false;
    }
    void LoseSceneTrigger()
    {
        gameEnding = true;
        Debug.Log("YOU LOSE!");
        SceneManager.LoadScene("Lose Scene");
    }
}
