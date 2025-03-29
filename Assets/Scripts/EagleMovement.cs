using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EagleMovement : MonoBehaviour
{
    public float speed = 2f;
    public Vector2 moveDirection = Vector2.left;
    
    void Update()
    {
        GetComponent<Rigidbody2D>().velocity = moveDirection * speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Boundary"))
        {
            moveDirection = -moveDirection;
            FlipSprite();
        }
    }

    private void FlipSprite()
    {
        Vector3 localScale = transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;  
    }
}
