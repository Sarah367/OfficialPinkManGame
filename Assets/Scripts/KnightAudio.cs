using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnightAudio : MonoBehaviour
{
    public Transform player;
    private AudioSource knightAudioSource;
    public float triggerDistance = 5f;
    private void Start()
    {
        knightAudioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        float distance = Vector3.Distance(transform.position, player.position);

        if (distance <= triggerDistance)
        {
            if (!knightAudioSource.isPlaying)
            {
                knightAudioSource.Play();
            }
        }
        else
        {
            if (knightAudioSource.isPlaying)
            {
                knightAudioSource.Stop();
            }
        }
        }
    }

