using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class movement : MonoBehaviour
{
    CharacterController characterController;
    float speed = 20f;
    public float acceleratorPower = 80f;
    public float maxSpeed = 50f;
    public float turnPower = 150f;
    public float naturalDeceleration = 20f;
    public float idleSpeed = 4f;
    public InputAction joystick;
    public InputAction reset;
    private Vector3 moveDirection = Vector3.zero;

    private float turnSpeed = 2f;
    
    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        joystick.Enable();
        reset.Enable();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 move = joystick.ReadValue<Vector2>();

        float turnAmount = Time.deltaTime * move.x * turnPower;
        Quaternion turn = Quaternion.Euler(0, turnAmount, 0);
        transform.forward = turn * transform.forward;

        float acceleration = move.y * acceleratorPower * Time.deltaTime;

        // slow down automatically (friction and stuff) -- i.e. reduce absolute magnitude of speed over time
        if (speed > idleSpeed)
            acceleration -= naturalDeceleration * Time.deltaTime; // reduce abs magnitude by becoming less positive
        else if (speed < -idleSpeed)
            acceleration += naturalDeceleration * Time.deltaTime; // reduce abs magnitude by becoming less negative

        speed += acceleration;
        speed = Mathf.Clamp(speed, -maxSpeed, maxSpeed);
        
        characterController.Move(transform.forward * (speed * Time.deltaTime));

        if (moveDirection != Vector3.zero)
        {
            transform.forward = moveDirection;
        }

        if (reset.triggered)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
