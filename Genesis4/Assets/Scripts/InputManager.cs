using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    private PlayerInput playerInput;
    private PlayerInput.PlayerActions Player;
    private PlayerMotor motor;
    private PlayerLook look;

    void Awake()
    {
        playerInput = new PlayerInput();
        Player = playerInput.Player;
        motor = GetComponent<PlayerMotor>();
        look = GetComponent<PlayerLook>();

        Player.Jump.performed += ctx => motor.Jump();
    }

    void Update()
    {
        // Process movement input
        motor.ProcessMove(Player.Movement.ReadValue<Vector2>());

        // Process look input
        look.ProcessLook(Player.Look.ReadValue<Vector2>());
    }

    private void OnEnable()
    {
        Player.Enable();
    }

    private void OnDisable()
    {
        Player.Disable();
    }
}
