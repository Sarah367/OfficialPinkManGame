using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMusicManager : MonoBehaviour
{
    public AudioSource backgroundMusic;
    private static BackgroundMusicManager instance;
    // Start is called before the first frame update
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        
    }
    private void Start()
    {
        if (backgroundMusic != null)
        {
            backgroundMusic.loop = true;
            float savedVolume = PlayerPrefs.GetFloat("volume", 1f);
            SetVolume(savedVolume);
            backgroundMusic.Play();
        }
        else
        {
            Debug.LogError("Not assigned.");
        }
    }
    //void Update()
    //{
    //    if (Input.GetKeyDown(KeyCode.V))
    //    {
    //        float currentVolume = PlayerPrefs.GetFloat("volume", -1f);
    //        Debug.Log("Current saved volume: " + currentVolume);
    //    }
    //}

    public void SetVolume(float volume)
    {
        if (backgroundMusic != null)
        {
            backgroundMusic.volume = volume;
            PlayerPrefs.SetFloat("volume", volume);
            PlayerPrefs.Save();
        }
    }
}
