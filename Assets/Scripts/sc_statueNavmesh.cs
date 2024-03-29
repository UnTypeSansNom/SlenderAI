using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class sc_statueNavmesh : MonoBehaviour
{
    public Transform player; // Reference to the other object
    public float maxAngle = 60f; // Maximum angle allowed

    public float moveSpeed = 3f; // Speed of the monster
    public float chaseRange = 10f; // Distance at which the monster starts chasing the player
    public float killRange = 1f; // Distance at which the monster kills the player

    private bool isChasing = false; // Flag to track if the monster is chasing the player
    public NavMeshAgent agent; // Reference to the NavMeshAgent component
    public LayerMask check;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>(); // Get the NavMeshAgent component
        agent.speed = moveSpeed;
    }

    void Update()
    {
        if (player != null)
        {
            // Calculate the angle between the forward direction of the script's object and the other object's forward direction
            float angle = Vector3.Angle(transform.position - player.position, player.forward);
            Vector3 v1 = transform.position;
            v1 = Vector3.Scale(v1, new Vector3(1, 0, 1)) + Vector3.up;
            Vector3 v2 = player.position;
            v2 = Vector3.Scale(v2, new Vector3(1, 0, 1)) + Vector3.up;

            // Check if the angle is less than the maximum angle allowed
            if (angle > maxAngle && Vector3.Distance(transform.position, player.position) <= chaseRange &&
            !Physics.Raycast(v1, v2, Vector3.Distance(v1, v2), check))
            {
                isChasing = true;
            }
            else
            {
                isChasing = false;
            }
        }
        else
        {
            Debug.LogWarning("Other object is not assigned!");
        }

        // If the monster is chasing, move towards the player
        if (isChasing)
        {
            agent.SetDestination(player.position - Vector3.up * 2);
            agent.isStopped = false;


            Vector3 angle = player.position - transform.position;

            // Calculate the rotation needed to look at the target object
            Quaternion targetRotation = Quaternion.LookRotation(angle);

            // Convert the rotation to only affect rotation around the y-axis
            targetRotation.eulerAngles = new Vector3(0, targetRotation.eulerAngles.y, 0);

            // Apply the rotation to the object
            transform.rotation = targetRotation;


            // Check if the player is within kill range
            if (Vector3.Distance(transform.position, player.position) <= killRange)
            {
                KillPlayer();
            }
        }
        else
        {
            agent.isStopped = true;
        }
    }

    void KillPlayer()
    {
        // You can implement whatever logic you want for killing the player here.
        // For example, you might reload the level, play a death animation, or show a game over screen.
        Debug.Log("Player has been killed by the monster!");
        // Example: You could reload the level
        // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
