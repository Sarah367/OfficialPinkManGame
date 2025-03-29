
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class StartMenu : MonoBehaviour
{
    void Start()
    {
        float savedVolume = PlayerPrefs.GetFloat("MasterVolumeSlider", 1f);

        AudioListener.volume = savedVolume;
        BackgroundMusicManager musicManager = FindObjectOfType<BackgroundMusicManager>();

        savedVolume = PlayerPrefs.GetFloat("volume", 1f);
        musicManager.SetVolume(savedVolume);
    }
    public void StartGame()
    {
        if (PlayerPrefs.GetInt("GameSaved", 0) == 1)
        {
            int savedScene = PlayerPrefs.GetInt("SavedScene", 1);
            SceneManager.LoadScene(savedScene);

            ItemCollector.oranges = PlayerPrefs.GetInt("SavedOranges", 0);
            ItemCollector.kiwis = PlayerPrefs.GetInt("SavedKiwis", 0);
            ItemCollector.strawberries = PlayerPrefs.GetInt("SavedStrawberries", 0);
            ItemCollector.princessItems = PlayerPrefs.GetInt("SavedPrincessItems", 0);
        } 
        else 
        {
            ItemCollector.Reset();
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        
    }
    
    public GameObject options;
    public void OpenOptions()
    {
        options.SetActive(true);
        //gameObject.SetActive(false);
        Debug.Log("Options Menu Opened");
    }
    public void CloseOptions()
    {
        options.SetActive(false);
        gameObject.SetActive(true);
    }
    private bool pause = false;
    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Exit");
    }
    public void OnPauseButtonClick()
    {
        TogglePause();
        Debug.Log("Paused!");
    }
    private void TogglePause()
    {
        pause = !pause;
        if (pause)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }
    }
}