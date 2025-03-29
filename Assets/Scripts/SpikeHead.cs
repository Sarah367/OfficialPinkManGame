using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeHead : MonoBehaviour
{
    private Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            ContactPoint2D contactPoint = collision.GetContact(0);
            Vector2 collisionDirection = contactPoint.point - (Vector2)transform.position;
            // Horizontal
            if (Mathf.Abs(collisionDirection.x) > Mathf.Abs(collisionDirection.y))
            {
                if (collisionDirection.x > 0)
                {
                    TriggerAnimation("HitRight");
                }
                else
                {
                    TriggerAnimation("HitLeft");
                }
            } else // Vertical
            {
                if (collisionDirection.y > 0)
                {
                    TriggerAnimation("HitTop");
                } else
                {
                    TriggerAnimation("HitBottom");
                }
            }
        }
    }

    private void TriggerAnimation(string triggerName)
    {
        animator.SetTrigger(triggerName);
    }
}
