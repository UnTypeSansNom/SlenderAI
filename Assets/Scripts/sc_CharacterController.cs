using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sc_CharacterController : MonoBehaviour
{
    public float moveSpeed = 5f; // Speed of player movement
    public float mouseSensitivity = 100f; // Mouse sensitivity for looking around
    CharacterController controller; // Reference to the CharacterController component
    float verticalRotation = 0f; // Stores vertical rotation

    void Start()
    {
        controller = GetComponent<CharacterController>(); // Get the CharacterController component
        Cursor.lockState = CursorLockMode.Locked; // Lock cursor to center of screen
    }

    void Update()
    {
        // Calculate movement direction based on input
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 moveDirection = transform.right * horizontalInput + transform.forward * verticalInput;

        // Move the player
        controller.Move(moveDirection.normalized * moveSpeed * Time.deltaTime);

        // Calculate rotation based on mouse input
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        // Rotate the player horizontally
        transform.Rotate(Vector3.up * mouseX);

        // Rotate the camera vertically
        verticalRotation -= mouseY;
        verticalRotation = Mathf.Clamp(verticalRotation, -90f, 90f); // Clamp vertical rotation to avoid flipping
        Camera.main.transform.localRotation = Quaternion.Euler(verticalRotation, 0f, 0f);
    }
}
