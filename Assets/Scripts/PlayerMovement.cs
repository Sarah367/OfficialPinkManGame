using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private SpriteRenderer sprite;
    private Animator anim;
    private float dirX = 0f;

    // Move these variables into the Unity editor in order to find the perfect speed and jump force.
    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private float jumpForce = 14f;
    [SerializeField] private float boostedSpeed = 14f;
    [SerializeField] private float iceSpeed = 3f;

    private bool isBoosted = false;
    private bool onIce = false;
    //private float boostDuration = 5f;
    public int jumpLimit;
    public int jumpCount = 0;
    [SerializeField] private AudioSource jumpSoundEffect;
    [SerializeField] private Text jumpCountText;
    private void Start()
    {
        Debug.Log(Time.timeScale);
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        jumpCount = 0;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("WoodenPlatform"))
        {
            transform.parent = collision.transform;
        }

        if (collision.gameObject.layer == LayerMask.NameToLayer("Ice"))
        {
            Debug.Log("Player stepped on ICE");
            onIce = true;
            moveSpeed = iceSpeed;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("WoodenPlatform"))
        {
            transform.parent = null;
        }
        if (collision.gameObject.layer == LayerMask.NameToLayer("Ice"))
        {
            Debug.Log("Player got off ICE!");
            onIce = false;
            moveSpeed = isBoosted ? boostedSpeed : 7f;
        }
    }
    // Update is called once per frame
    private void Update()
    {
        dirX = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);
        if (Input.GetButtonDown("Jump"))
        {
            PerformJump();
        }

        UpdateAnimationState();
    }
    private void PerformJump()
    {
            if (jumpCount < jumpLimit)
            {
                jumpSoundEffect.Play();
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
                jumpCount++;
                PlayerPrefs.SetInt("SavedJumps", jumpCount);
                PlayerPrefs.Save();
                Debug.Log("Jump Count: " + jumpCount);
                if (jumpCountText != null)
                {
                    jumpCountText.text = "Jumps: " + jumpCount + " / " + jumpLimit;
                }
                
        }
            else
            {
                SceneManager.LoadScene("Lose Scene");
            }
        }
        
private void UpdateAnimationState()
    {
        if (dirX > 0f)
        {
            anim.SetBool("running", true);
            sprite.flipX = false;
        }
        else if (dirX < 0f)
        {
            anim.SetBool("running", true);
            sprite.flipX = true;
        }
        else
        {
            anim.SetBool("running", false);
        }
    }
public void ActivateSpeedBoost(float duration)
    {
        if (!isBoosted)
        {
            isBoosted = true;
            moveSpeed = boostedSpeed;
            Invoke("ResetSpeed", duration);
        }
    }
    private void ResetSpeed()
    {
        moveSpeed = 7f;
        isBoosted = false;
    }

}
