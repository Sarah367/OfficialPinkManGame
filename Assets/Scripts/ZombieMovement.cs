using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ZombieMovement : MonoBehaviour
{
    public Transform[] patrolPoints;
    public float moveSpeed;
    public int patrolDestination;
    private AudioSource audioSource;
    private Vector3 initialScale;
    void Start()
    {
        initialScale = transform.localScale;
    }
    void Update()
    {
        if (patrolDestination == 0)
        {
            transform.position = Vector2.MoveTowards(transform.position, patrolPoints[0].position, moveSpeed * Time.deltaTime);
            if (Vector2.Distance(transform.position, patrolPoints[0].position) < .2f)
            {
                transform.localScale = new Vector3(Mathf.Abs(initialScale.x), initialScale.y, initialScale.z);
                patrolDestination = 1;

            }

        }
        if (patrolDestination == 1)
        {
            transform.position = Vector2.MoveTowards(transform.position, patrolPoints[1].position, moveSpeed * Time.deltaTime);
            if (Vector2.Distance(transform.position, patrolPoints[1].position) < .2f)
            {
                transform.localScale = new Vector3(-Mathf.Abs(initialScale.x), initialScale.y, initialScale.z);
                patrolDestination = 0;

            }

        }
    }



    private IEnumerator PlayEveryFiveSecs()
    {
        while (true)
        {
            audioSource.Play();
            yield return new WaitForSeconds(5f);
        }
    }
}

