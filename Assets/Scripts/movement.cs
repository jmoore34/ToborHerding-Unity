using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class movement : MonoBehaviour
{
    CharacterController characterController;
    public float speed;
    public float rotationSpeed;
    public InputAction joystick;
    public InputAction reset;
    private Vector3 moveDirection = Vector3.zero;
    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        characterController = GetComponent<CharacterController>();
        joystick.Enable();
        reset.Enable();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 move = joystick.ReadValue<Vector2>();

        moveDirection = new Vector3(move.x, 0.0f, move.y);
        moveDirection *= speed;

        characterController.Move(moveDirection * Time.deltaTime);

        if (moveDirection != Vector3.zero)
        {
            transform.forward = moveDirection;
            if(!anim.GetBool("Walk_Anim"))
                anim.SetBool("Walk_Anim", true);
        }
        else if (anim.GetBool("Walk_Anim"))
        {
            anim.SetBool("Walk_Anim", false);
        }

        if (reset.triggered)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
