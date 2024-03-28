using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sc_Statue : MonoBehaviour
{
    public Transform player; // Reference to the other object
    public float maxAngle = 60f; // Maximum angle allowed

    public float moveSpeed = 3f; // Speed of the monster
    public float chaseRange = 10f; // Distance at which the monster starts chasing the player
    public float killRange = 1f; // Distance at which the monster kills the player

    private bool isChasing = false; // Flag to track if the monster is chasing the player

    void Update()
    {
        if (player != null)
        {
            // Calculate the angle between the forward direction of the script's object and the other object's forward direction
            float angle = Vector3.Angle(transform.position - player.position, player.forward);

            // Check if the angle is less than the maximum angle allowed
            if (angle > maxAngle && Vector3.Distance(transform.position, player.position) <= chaseRange)
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
            Vector3 direction = player.position - transform.position;
            direction.y = 0; // Ensure the monster stays on the same level as the player
            transform.Translate(direction.normalized * moveSpeed * Time.deltaTime);


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
