using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    [Header("Look Settings")]
    public float sensitivity = 3f;
    public Transform cameraTransform;

    private Vector2 lookInput;
    private float xRotation = 0f;

    void Start()
    {
        // Lock the cursor to the center of the screen
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        // Rotate the player body for horizontal movement (yaw)
        transform.Rotate(Vector3.up * lookInput.x * sensitivity);

        // Rotate the camera for vertical movement (pitch)
        xRotation -= lookInput.y * sensitivity;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);  // Clamp rotation to avoid flipping
        cameraTransform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
    }

    // This function is called from InputManager
    public void ProcessLook(Vector2 input)
    {
        lookInput = input;
    }
}
