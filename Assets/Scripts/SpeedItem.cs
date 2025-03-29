using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedItem : MonoBehaviour
{
    public float boostDuration = 5f;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerMovement player = other.GetComponent<PlayerMovement>();
            if (player != null)
            {
                Debug.Log("PLAYER COLLECTED SPEED BOOST");
                player.ActivateSpeedBoost(boostDuration);
            }
            Destroy(gameObject);
        }
    }

}
