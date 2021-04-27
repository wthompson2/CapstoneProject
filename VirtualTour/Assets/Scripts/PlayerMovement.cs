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
    private PlayerMovementInfo playerMovementInfo;

    void Start()
    {
        animator = GetComponent<Animator>();
        characterController = GetComponent<CharacterController>();
        characterController.minMoveDistance = 0.0f; // needed to fix isGrounded instability

        playerMovementInfo = new PlayerMovementInfo();
        playerMovementInfo.baseSpeed = baseSpeed;
        playerMovementInfo.runningAmplifier = runningAmplifier;

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
        // if (Input.GetButtonDown("Jump") && grounded)
        // {
        //     Debug.Log(">>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>JUMP");
        //     playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravity);
        // }

        playerVelocity.y += gravity * Time.deltaTime;
        characterController.Move(playerVelocity * Time.deltaTime);
    }
    // ---------------------------------------------------------------------------------------------------------------------------
    public void ProcessInput()
    {
        //Debug.Log("ProcessInput. characterController.isGrounded: " + characterController.isGrounded);

        if (characterController.isGrounded)
        {
            playerMovementInfo.leftAndRight = Input.GetAxis("Horizontal"); // A and D
            playerMovementInfo.forwardAndBackward = Input.GetAxis("Vertical"); // W and S. Range -1...1

            // playerMovementInfo.jump = Input.GetButtonDown("Jump");


            playerMovementInfo.movingForwards = playerMovementInfo.forwardAndBackward > 0.0f;
            playerMovementInfo.movingBackwards = playerMovementInfo.forwardAndBackward < 0.0f;

            bool running = (playerMovementInfo.movingForwards && Input.GetKey(KeyCode.LeftShift))
                           ||
                           (!playerMovementInfo.movingBackwards
                             &&
                             (playerMovementInfo.leftAndRight > 0.0f || playerMovementInfo.leftAndRight < 0.0f)
                           );

            if (running)
            {
                playerMovementInfo.speed = playerMovementInfo.baseSpeed * playerMovementInfo.runningAmplifier;
            }
            else
            {
                playerMovementInfo.speed = playerMovementInfo.baseSpeed;

                playerMovementInfo.forwardAndBackward = playerMovementInfo.forwardAndBackward / 2.0f;
            }
        }
    }

    // ---------------------------------------------------------------------------------------------------------------------------
    public void PerformBlendTreeAnimation()
    {
        float leftAndRight = playerMovementInfo.leftAndRight;

        if (playerMovementInfo.movingBackwards)
        {
            leftAndRight = 0.0f;
        }

        animator.SetFloat("leftAndRight", leftAndRight);
        animator.SetFloat("forwardAndBackward", playerMovementInfo.forwardAndBackward);
    }

    // ---------------------------------------------------------------------------------------------------------------------------
    public void CalculateDirectionAndDistance()
    {
        Vector3 moveDirectionForward = transform.forward * playerMovementInfo.forwardAndBackward;
        Vector3 moveDirectionSide    = transform.right * playerMovementInfo.leftAndRight;
        //Vector3 moveDirectionUp      = transform.up * 1;

        playerMovementInfo.direction = moveDirectionForward + moveDirectionSide; 
        playerMovementInfo.normalizedDirection = playerMovementInfo.direction.normalized;

        playerMovementInfo.distance = playerMovementInfo.normalizedDirection * playerMovementInfo.speed * Time.deltaTime;

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
        characterController.Move(playerMovementInfo.distance);
    }

    // ---------------------------------------------------------------------------------------------------------------------------
    public void GroundPlayer()
    {
        if (characterController.isGrounded)
        {
            airTime = 0;
            playerMovementInfo.normalizedDirection.y = 0;
            playerMovementInfo.distance.y = 0;
        }
        else // falling
        {
            Debug.Log("GroundPlayer. falling and characterController.isGrounded: " + characterController.isGrounded);
            airTime += Time.deltaTime;
            Vector3 direction = playerMovementInfo.normalizedDirection;
          
            direction.y += 0.5f * gravity * airTime;
          
            playerMovementInfo.normalizedDirection = direction;
            playerMovementInfo.distance = playerMovementInfo.normalizedDirection * airTime;
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
