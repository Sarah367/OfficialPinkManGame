using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trampoline : MonoBehaviour
{
    private AudioSource audioSource;
    private Animator animator;
    [SerializeField] private float jumpForce = 10f;
    [SerializeField] private AudioClip trampolineSound;
    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (collision.contacts[0].point.y > transform.position.y)
            {
                if (trampolineSound != null && audioSource != null)
                {
                    audioSource.PlayOneShot(trampolineSound);
                }
                animator.SetTrigger("jumping");

                Rigidbody2D playerRb = collision.gameObject.GetComponent<Rigidbody2D>();
                if (playerRb != null)
                {
                    playerRb.velocity = new Vector2(playerRb.velocity.x, jumpForce);
                }
            }
            
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("PLAYER LEFT THE TRAMPOLINE!");
            animator.ResetTrigger("jumping");
        }
    }
}
