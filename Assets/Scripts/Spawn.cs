using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Spawn : MonoBehaviour
{
    [SerializeField] private AudioSource spawnSoundEffect;
    // Start is called before the first frame update
    private void Start()
    {
        if (SceneManager.GetActiveScene().buildIndex > 1)
        {
            PlaySpawnSound();
        }
        
    }

    // Update is called once per frame
    private void PlaySpawnSound()
    {
        if (spawnSoundEffect != null)
        {
            spawnSoundEffect.Play();
        }
        else
        {
            Debug.LogWarning("Spawn not working!");
        }
    }
}
