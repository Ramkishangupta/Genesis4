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
        if (cameraTransform == null)
        {
            cameraTransform = Camera.main?.transform;
            if (cameraTransform == null)
            {
                Debug.LogError("PlayerLook: No Camera found! Assign it in the Inspector.");
            }
        }

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        if (cameraTransform == null)
        {
            Debug.LogError("PlayerLook: CameraTransform is NULL in Update!");
            return;
        }

        transform.Rotate(Vector3.up * lookInput.x * sensitivity);
        xRotation -= lookInput.y * sensitivity;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        cameraTransform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
    }

    public void ProcessLook(Vector2 input)
    {
        lookInput = input;
    }
}
