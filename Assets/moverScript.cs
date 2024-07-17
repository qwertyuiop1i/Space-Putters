using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moverScript : MonoBehaviour
{
    public List<Vector2> waypoints;
    public float moveSpeed = 2f;
    private int currentWaypointIndex = 0;

    private void Start()
    {
        transform.position = waypoints[0];
    }
    void Update()
    {
        if (waypoints.Count > 0)
        {
            Vector2 targetPosition = waypoints[currentWaypointIndex];
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);

            if (Vector2.Distance(transform.position, targetPosition) < 0.1f)
            {
                currentWaypointIndex++;
                if (currentWaypointIndex >= waypoints.Count)
                {
                    currentWaypointIndex = 0;
                }
            }
        }
    }
}
