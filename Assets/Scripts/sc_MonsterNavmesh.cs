using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class sc_MonsterNavmesh : MonoBehaviour
{
    public Transform player; // Reference to the player's transform
    public float moveSpeed = 3f; // Speed of the monster
    public float chaseRange = 10f; // Distance at which the monster starts chasing the player
    public float killRange = 1f; // Distance at which the monster kills the player

    private bool isChasing = false; // Flag to track if the monster is chasing the player
    public NavMeshAgent agent; // Reference to the NavMeshAgent component

    Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>(); // Get the NavMeshAgent component
    }

    void Update()
    {
        // Check if the player is within the chase range
        if (Vector3.Distance(transform.position, player.position) <= chaseRange)
        {
            isChasing = true;
            animator.SetBool("Move", true);
        }
        else
        {
            isChasing = false;
            animator.SetBool("Move", false);
        }

        // If the monster is chasing, move towards the player
        if (isChasing)
        {
            agent.SetDestination(player.position);

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
