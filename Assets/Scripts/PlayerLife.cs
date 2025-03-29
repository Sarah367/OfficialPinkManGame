using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;

    [SerializeField] private AudioSource dyingSound;

    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Zombie") || collision.gameObject.CompareTag("Gap"))
        {
            Die();
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collided with: " + collision.gameObject.name);
        if (collision.gameObject.CompareTag("Trap") || collision.gameObject.CompareTag("Zombie") || collision.gameObject.CompareTag("FireTrap") || collision.gameObject.CompareTag("SpikesTrap") || collision.gameObject.CompareTag("RotatingSaw") || collision.gameObject.CompareTag("SpikeHead") || collision.gameObject.CompareTag("Knight"))
        {
            Die();
        }
    }

    private void Die()
    {
        dyingSound.Play();
        rb.bodyType = RigidbodyType2D.Static;
        anim.SetTrigger("Death");
        if (SceneManager.GetActiveScene().buildIndex == 11)
        {
            SceneManager.LoadScene("Lose Scene");
        }
        if (SceneManager.GetActiveScene().buildIndex == 8 || SceneManager.GetActiveScene().buildIndex == 9)
        {
            TimeLimit timer = FindObjectOfType<TimeLimit>();
            if (timer != null)
            {
                timer.TimerReset();
            }
        }
        ItemCollector.Reset();
    }

    private void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
