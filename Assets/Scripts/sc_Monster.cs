using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sc_Monster : MonoBehaviour
{
    public Transform player; // Reference to the player's transform
    public float moveSpeed = 3f; // Speed of the monster
    public float chaseRange = 10f; // Distance at which the monster starts chasing the player
    public float killRange = 1f; // Distance at which the monster kills the player

    private bool isChasing = false; // Flag to track if the monster is chasing the player

    Animator animator;
    float _hauteur;

    private void Start()
    {
        animator = GetComponent<Animator>();
        _hauteur = transform.position.y;
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
            Vector3 direction = player.position - transform.position;
            direction.y = 0; // Ensure the monster stays on the same level as the player
            transform.Translate(direction.normalized * moveSpeed * Time.deltaTime);
            transform.LookAt(player.position - Vector3.up * 0.5f, Vector3.up);
            transform.position = new Vector3(transform.position.x, _hauteur, transform.position.z);
            // Check if the player is within kill range
            if (Vector3.Distance(transform.position, player.position) <= killRange)
            {
                KillPlayer();
            }
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
