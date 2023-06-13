using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AyaOmar
{
    public class WaypointMovement : MonoBehaviour
    {
        public Transform[] waypoints;  // Array to hold the waypoints
        public float speed = 5f;       // Speed at which the object moves

        private int currentWaypointIndex = 0;

        private void Update()
        {
            Move();
        }
        private void Move()
        {
            if (waypoints.Length == 0)
            {
                Debug.LogWarning("No waypoints assigned.");
                return;
            }

            // Move towards the current waypoint
            Transform currentWaypoint = waypoints[currentWaypointIndex];
            transform.position = Vector3.MoveTowards(transform.position, currentWaypoint.position, speed * Time.deltaTime);
            transform.LookAt(waypoints[currentWaypointIndex]);
            // Check if the object has reached the current waypoint
            if (transform.position == currentWaypoint.position)
            {
                // Move to the next waypoint
                currentWaypointIndex++;
                if (currentWaypointIndex >= waypoints.Length)
                {
                    // If all waypoints have been visited, reset to the first waypoint
                    currentWaypointIndex = 0;
                }
            }

        }
    }
}
