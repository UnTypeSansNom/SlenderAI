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
    public LayerMask check;

    Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>(); // Get the NavMeshAgent component
        agent.speed = moveSpeed;
    }

    void Update()
    {
        Vector3 v1 = transform.position;
        v1 = Vector3.Scale(v1, new Vector3(1, 0, 1)) + Vector3.up;
        Vector3 v2 = player.position;
        v2 = Vector3.Scale(v2, new Vector3(1, 0, 1)) + Vector3.up;
        // Check if the player is within the chase range
        if (Vector3.Distance(transform.position, player.position) <= chaseRange &&
            !Physics.Raycast(v1, v2, Vector3.Distance(v1, v2), check))
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
            agent.SetDestination(player.position - Vector3.up*2);
            agent.isStopped = false;

            if (Vector3.Distance(new Vector3(transform.position.x, 0, transform.position.z),
                new Vector3(player.position.x, 0, player.position.z)) <= killRange)
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
