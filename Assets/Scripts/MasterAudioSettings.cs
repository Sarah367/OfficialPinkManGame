using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MasterAudioSettings : MonoBehaviour
{
    [SerializeField] public Slider masterVolume;
    // Start is called before the first frame update
    private void Start()
    {
        float savedVolume = PlayerPrefs.GetFloat("MasterVolumeSlider", 1f);
        AudioListener.volume = savedVolume;
        masterVolume.value = savedVolume;
        masterVolume.onValueChanged.AddListener(SetMasterVolume);
    }

    // Update is called once per frame
    private void SetMasterVolume(float volume)
    {
        AudioListener.volume = volume;
        PlayerPrefs.SetFloat("MasterVolumeSlider", volume);
        PlayerPrefs.Save();
    }
}
