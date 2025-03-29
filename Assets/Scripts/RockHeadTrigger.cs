using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockHeadTrigger : MonoBehaviour
{
    private Animator animator;

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
                animator.SetTrigger("Activate");
            }
        }
    }
}
