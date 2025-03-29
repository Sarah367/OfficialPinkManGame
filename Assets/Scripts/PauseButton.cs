using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseButton : MonoBehaviour
{
    public Text PauseText;

    private bool isPause = false;
    public void TogglePause()
    {
        if (isPause)
        {
            Resume();
        } 
        else
        {
            Pause();
        }
    }

    private void Pause()
    {
        Debug.Log("PAUSED");
        Time.timeScale = 0f;
        isPause = true;
        PauseText.text = "RESUME GAME";
    }
    private void Resume()
    {
        Debug.Log("RESUMED");
        Time.timeScale = 1f;
        isPause = false;
        PauseText.text = "PAUSE GAME";
    }
}
