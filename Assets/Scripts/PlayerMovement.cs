using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerMovement : MonoBehaviour
{
    private CharacterController controller;
    private float playerSpeed = 2.0f;
    private float jumpHeight = 1.0f;
    private float gravityValue = -9.81f;
    private bool groundedPlayer;
    private bool Jump = false;
    private bool Move = false;
    private Vector3 playerVelocity, direction;

    void Start()
    {
        controller = gameObject.GetComponent<CharacterController>();
    }

    void Update()
    {    

        groundedPlayer = controller.isGrounded;
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }

        direction = Vector3.zero;
        if (Move)
        {
            direction = gameObject.transform.forward;
        }

        controller.Move(direction * Time.deltaTime * playerSpeed);

        if (Jump && groundedPlayer)
        {
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
            Jump = false;
        }

        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);
  
    }

    public void Jumping()
    {
        Jump = true;
    }
    public void Moving()
    {
        Move = true;
    }
    public void StopMoving()
    {
        Move = false;
    }
}
