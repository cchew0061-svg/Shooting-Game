using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMotor : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 playerVelocity;
    public bool isGrounded;
    public float speed = 3f;
    public float gravity = -9.8f;
    public float jumpHeight = 0.7f;
    public float walkSpeed = 3f;
    public float crouchSpeed = 1f;
    //variable values determined

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    //receive inputs for InputManager.cs and apply to character controller
    void Update()
    {
        isGrounded = controller.isGrounded;   
    }

    //allows player to walk
    public void ProcessMove(Vector2 input)
    {
        Vector3 moveDirection = Vector3.zero;
        moveDirection.x = input.x;
        moveDirection.z = input.y;
        controller.Move(transform.TransformDirection(moveDirection) * speed * Time.deltaTime);
        playerVelocity.y += gravity * Time.deltaTime;
        if (isGrounded && playerVelocity.y < 0)
        {
            playerVelocity.y = -2f;
        }
        controller.Move(playerVelocity * Time.deltaTime);
    }

    //allows player to jump
    public void Jump()
    {
        if (isGrounded)
        {
            playerVelocity.y = Mathf.Sqrt(jumpHeight * -3.0f * gravity);
        }
    }

    //allows player to toggle between crouch mode and walk mode
    public bool crouch;
    public void CrouchChange()
    {
        crouch = !crouch;  
        if (crouch)
        {
            controller.height = 1f;
            speed = crouchSpeed;
    	}
    	else
    	{
            controller.height = 3f;
            speed = walkSpeed;
    	}
    }
}

