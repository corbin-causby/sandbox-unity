using UnityEngine;
using UnityEngine.AI;

public class ThirdPersonMovement : MonoBehaviour
{
    // Think of character controller as motor that runs our character,
    // and we have to tell the motor where to go.
    public CharacterController controller;
    public Transform cam;

    float moveSpeed;
    public float walkSpeed = 6f;
    public float sprintSpeed = 12f;


    public float gravity = -9.81f; 
    public float jumpHeight = 3f;   
    public float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    Vector3 velocity;
    public KeyCode sprintKey = KeyCode.LeftShift;
    public KeyCode jumpKey = KeyCode.Space;
    bool isGrounded; 



    public MovementState state;

    public enum MovementState
    {
        walking,
        sprinting,
        air,
    }

    // Update is called once per frame
    void Update()
    {
        // ground check
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        StateHandler();

        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        // We want to move our character on the x andf z axis but not the y but all 3d components are a vector3

        float horizontal = Input.GetAxisRaw("Horizontal"); // Horizontal stands for A and D keys
        float vertical = Input.GetAxisRaw("Vertical"); // Vertical stands for the W and S keys
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized; // Vector3 class takes the X, Y, and Z as an argument
        // or you could add the x by doing direction.x = Input.GetAxisRaw("Horizontal") 
        // .normalized makes it so that when you are pressing two keys you are not going faster than the dedicated speed

        if(direction.magnitude >= 0.1f) // .magnitude is length of direction vector; checking for any of the keys being pressed
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y; // points player object in the direction the player is moving 
            // Atan takes point the character is already looking and then the direction it ends and creates angle.
            // This angle is then used below for the rotation of the CharacterController controllers transform being our player object
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime); // Look up documentation for Mathf.SmoothDampAngle, idk what this really does besides smoothing out the angle in unity
            // This below creates rotation to the direction that the model is going in,
            // first creating the target angle then smoothing it out and using that smoothed angle
            transform.rotation = Quaternion.Euler(0f, angle, 0f);


            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward; // dont really know what this does but it makes it so the character move direction is a combonation of the cameras direction and the characters direction inputted
            controller.Move(moveDir.normalized * moveSpeed * Time.deltaTime); //Move funtion selects a given direction, once a direction key is inputted, 
            // then multiplies it by speed which adds a force to the character
            // Time.deltaTime makes it framerate independent...whatever that means
        }

        // Applying jump
        if(Input.GetKeyDown(jumpKey) && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
        
        // Applying gravity below
        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }

    private void StateHandler()
    {
        // move state: sprinting
        if(isGrounded &&  Input.GetKey(sprintKey))
        {
            state = MovementState.sprinting;
            moveSpeed = sprintSpeed;
        }

        // move state: walking
        else if(isGrounded)
        {
            state = MovementState.walking;
            moveSpeed = walkSpeed;
        }

        // move state: air
        else
        {
            state = MovementState.air;
        }
    }
}
