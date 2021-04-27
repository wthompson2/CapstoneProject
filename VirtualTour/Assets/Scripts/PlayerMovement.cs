using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float baseSpeed;
    public float runningAmplifier;

    public bool lockCursor;

    private CharacterController characterController;
    private Animator animator;

    private float airTime;
    private float gravity = -9.81f;
    private float jumpHeight = 3.0f;
    private Vector3 playerVelocity;
    private bool grounded;
    private PlayerMovementInfo playerMovement;

    void Start()
    {
        animator = GetComponent<Animator>();
        characterController = GetComponent<CharacterController>();
        characterController.minMoveDistance = 0.0f; // needed to fix isGrounded instability

        playerMovement = new PlayerMovementInfo();
        playerMovement.baseSpeed = baseSpeed;
        playerMovement.runningAmplifier = runningAmplifier;

        if (lockCursor)
        {
            Cursor.lockState = CursorLockMode.Locked;
        }

        airTime = 0;

        playerVelocity = Vector3.zero;
    }

    void Update()
    {
        grounded = characterController.isGrounded;
        //playerVelocity.y += gravity * Time.deltaTime;
        //characterController.Move(playerVelocity * Time.deltaTime);

        //Debug.Log("Update. characterController.isGrounded: " + characterController.isGrounded);

        if (grounded && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f; // erase falling velocity
        }

        ProcessInput();
        //
        PerformBlendTreeAnimation();
        //
        //GroundPlayer();
        CalculateDirectionAndDistance();
        PerformPhysicalMovement();
        //
        RotatePlayerWithCamera();

        // Changes the height position of the player..
        if (Input.GetButtonDown("Jump") && grounded)
        {
            Debug.Log(">>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>JUMP");
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravity);
        }

        playerVelocity.y += gravity * Time.deltaTime;
        characterController.Move(playerVelocity * Time.deltaTime);
    }
    // ---------------------------------------------------------------------------------------------------------------------------
    public void ProcessInput()
    {
        //Debug.Log("ProcessInput. characterController.isGrounded: " + characterController.isGrounded);

        if (characterController.isGrounded)
        {
            playerMovement.leftAndRight = Input.GetAxis("Horizontal"); // A and D
            playerMovement.forwardAndBackward = Input.GetAxis("Vertical"); // W and S. Range -1...1

            playerMovement.jump = Input.GetButtonDown("Jump");


            playerMovement.movingForwards = playerMovement.forwardAndBackward > 0.0f;
            playerMovement.movingBackwards = playerMovement.forwardAndBackward < 0.0f;

            bool running = (playerMovement.movingForwards && Input.GetKey(KeyCode.LeftControl))
                           ||
                           (!playerMovement.movingBackwards
                             &&
                             (playerMovement.leftAndRight > 0.0f || playerMovement.leftAndRight < 0.0f)
                           );

            if (running)
            {
                playerMovement.speed = playerMovement.baseSpeed * playerMovement.runningAmplifier;
            }
            else
            {
                playerMovement.speed = playerMovement.baseSpeed;

                playerMovement.forwardAndBackward = playerMovement.forwardAndBackward / 2.0f;
            }
        }
    }

    // ---------------------------------------------------------------------------------------------------------------------------
    public void PerformBlendTreeAnimation()
    {
        float leftAndRight = playerMovement.leftAndRight;

        if (playerMovement.movingBackwards)
        {
            leftAndRight = 0.0f;
        }

        animator.SetFloat("leftAndRight", leftAndRight);
        animator.SetFloat("forwardAndBackward", playerMovement.forwardAndBackward);
    }

    // ---------------------------------------------------------------------------------------------------------------------------
    public void CalculateDirectionAndDistance()
    {
        Vector3 moveDirectionForward = transform.forward * playerMovement.forwardAndBackward;
        Vector3 moveDirectionSide    = transform.right * playerMovement.leftAndRight;
        //Vector3 moveDirectionUp      = transform.up * 1;

        playerMovement.direction = moveDirectionForward + moveDirectionSide; 
        playerMovement.normalizedDirection = playerMovement.direction.normalized;

        playerMovement.distance = playerMovement.normalizedDirection * playerMovement.speed * Time.deltaTime;

        //playerMovement.distance.y = 0;
        //Debug.Log("CalculateDirectionAndDistance. playerMovement.normalizedDirection: " + playerMovement.normalizedDirection +
        //          "\n      CalculateDirectionAndDistance. playerMovement.distance: " + playerMovement.distance);
        // ------------------------------------------------------------------
        // https://docs.unity3d.com/ScriptReference/CharacterController.Move.html
        // Changes the height position of the player..
        // if (playerMovement.jump)
        // {
        //     playerMovement.distance.y += Mathf.Sqrt(jumpHeight * -3.0f * gravity);
        // }

        //playerMovement.distance.y += gravity * Time.deltaTime * Time.deltaTime;
        //controller.Move(playerVelocity * Time.deltaTime);
        // ------------------------------------------------------------------

    }


    // ---------------------------------------------------------------------------------------------------------------------------
    public void PerformPhysicalMovement()
    {
        //Debug.Log("PerformPhysicalMovement. playerMovement.distance: " + playerMovement.distance);
        characterController.Move(playerMovement.distance);
    }

    // ---------------------------------------------------------------------------------------------------------------------------
    public void GroundPlayer()
    {
        if (characterController.isGrounded)
        {
            airTime = 0;
            playerMovement.normalizedDirection.y = 0;
            playerMovement.distance.y = 0;
        }
        else // falling
        {
            Debug.Log("GroundPlayer. falling and characterController.isGrounded: " + characterController.isGrounded);
            airTime += Time.deltaTime;
            Vector3 direction = playerMovement.normalizedDirection;
          
            direction.y += 0.5f * gravity * airTime;
          
            playerMovement.normalizedDirection = direction;
            playerMovement.distance = playerMovement.normalizedDirection * airTime;
            //PerformPhysicalMovement();
        }
    }

    // ---------------------------------------------------------------------------------------------------------------------------
    public void RotatePlayerWithCamera ()
    {
        Vector3 rotation;

        if (Input.GetKey(KeyCode.T))
        {
            return;
        }
        else
        {
            rotation = Camera.main.transform.eulerAngles;
            rotation.x = 0;
            rotation.z = 0;

            transform.eulerAngles = rotation;
        }
    }
  
}
