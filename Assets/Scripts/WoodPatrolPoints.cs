using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodPatrolPoints : MonoBehaviour
{
    [SerializeField] private GameObject[] waypoints;
    private int currentWaypointIndex = 0;

    [SerializeField] private float speed = 2f;

    // Update is called once per frame
    private void Update()
    {
        Debug.Log("Current Waypoint: " + currentWaypointIndex + ", Position: " + waypoints[currentWaypointIndex].transform.position);

        if (Vector2.Distance(waypoints[currentWaypointIndex].transform.position, transform.position) < .5f)
        {
            currentWaypointIndex++;
            if (currentWaypointIndex >= waypoints.Length)
            {
                currentWaypointIndex = 0;
            }
        }
        transform.position = Vector2.MoveTowards(transform.position, waypoints[currentWaypointIndex].transform.position, Time.deltaTime * speed);
    }
}
