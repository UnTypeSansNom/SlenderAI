using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sc_KeyManager : MonoBehaviour
{
    public int keysNeeded = 3; // Number of keys needed to open the door
    public int keysBarriers = 3; // Number of keys needed to open the door
    public GameObject door; // Reference to the door GameObject
    public GameObject openDoor;
    public GameObject doorTuto, barriere;
    public AudioClip keyCollectedSound, doorOpenSound; // Sound to play when the door opens

    private int keysCollected = 0; // Number of keys collected

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Key"))
        {
            Destroy(other.transform.parent.gameObject); // Destroy the collected key
            keysCollected++; // Increment the number of keys collected
            Debug.Log("Key collected! Keys collected: " + keysCollected);
            AudioSource.PlayClipAtPoint(keyCollectedSound, transform.position); // Play key sound

            if(keysCollected >= 1) { doorTuto.SetActive(false); }
            if (keysCollected >= keysNeeded)
            {
                OpenDoor(); // Open the door if enough keys are collected
            }
            if(keysCollected >= keysBarriers) { barriere.SetActive(false); }
        }
    }

    void OpenDoor()
    {
        if (door != null)
        {
            door.SetActive(false); // Deactivate the door
            openDoor.SetActive(true);
            AudioSource.PlayClipAtPoint(doorOpenSound, door.transform.position); // Play door open sound
            Debug.Log("Door opened!");
        }
        else
        {
            Debug.LogError("Door GameObject is not assigned!");
        }
    }
}
