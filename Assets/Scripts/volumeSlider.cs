using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class volumeSlider : MonoBehaviour
{
    public Slider slider;
    public BackgroundMusicManager musicManager;
    // Start is called before the first frame update
    void Start()
    {
        musicManager = FindObjectOfType<BackgroundMusicManager>();

        float savedVolume = PlayerPrefs.GetFloat("volume", 1f);
        musicManager.SetVolume(savedVolume);
        slider.value = savedVolume;

        slider.onValueChanged.AddListener(OnVolumeChange);
    }

    // Update is called once per frame
    public void OnVolumeChange(float value)
    {
        musicManager.SetVolume(value);

        PlayerPrefs.SetFloat("volume", value);
        PlayerPrefs.Save();
    }
    
}
