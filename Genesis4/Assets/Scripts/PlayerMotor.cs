using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMotor : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 playerVelocity;
    private Vector2 movementInput;  // Declare movementInput here
    private bool isGrounded;
    private bool jumpPressed;

    [Header("Player Settings")]
    public float speed = 5f;
    public float jumpHeight = 2f;
    public float gravity = -9.81f;

    private void Awake()
    {
        controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
        // Check if the player is on the ground
        isGrounded = controller.isGrounded;

        // Apply gravity
        if (isGrounded && playerVelocity.y < 0)
        {
            playerVelocity.y = -2f;
        }

        // Move the player
        Vector3 move = transform.right * movementInput.x + transform.forward * movementInput.y;
        controller.Move(move * speed * Time.deltaTime);

        // Jumping
        if (jumpPressed && isGrounded)
        {
            playerVelocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            jumpPressed = false;
        }

        // Apply gravity to the player
        playerVelocity.y += gravity * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);
    }

    // Called from PlayerInputManager to handle movement input
    public void ProcessMove(Vector2 input)
    {
        movementInput = input;
    }

    // Called from PlayerInputManager to handle jumping
    public void Jump()
    {
        if (isGrounded)
        {
            jumpPressed = true;
        }
    }
}
