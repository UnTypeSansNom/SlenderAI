using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sc_KeyManager : MonoBehaviour
{
    public int keysNeeded = 3; // Number of keys needed to open the door
    public GameObject door; // Reference to the door GameObject
    public AudioClip doorOpenSound; // Sound to play when the door opens

    private int keysCollected = 0; // Number of keys collected

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Key"))
        {
            Destroy(other.transform.parent.gameObject); // Destroy the collected key
            keysCollected++; // Increment the number of keys collected
            Debug.Log("Key collected! Keys collected: " + keysCollected);

            if (keysCollected >= keysNeeded)
            {
                OpenDoor(); // Open the door if enough keys are collected
            }
        }
    }

    void OpenDoor()
    {
        if (door != null)
        {
            door.SetActive(false); // Deactivate the door
            AudioSource.PlayClipAtPoint(doorOpenSound, door.transform.position); // Play door open sound
            Debug.Log("Door opened!");
        }
        else
        {
            Debug.LogError("Door GameObject is not assigned!");
        }
    }
}
