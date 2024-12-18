using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //constants
    const float WalkingMoveSpeed = 2;
    const float RunningMoveSpeed = 3;

    const float JumpHeight = 3.5f;

    //variables
    private bool OnGround;
    private float MoveSpeed;

    private float horizontal;
    private float vertical;
    private float mouseX;

    Rigidbody rb;
    Animator cameraAnimator;
    
    // Start is called before the first frame update
    void Start()
    {
        OnGround = false;
        MoveSpeed = WalkingMoveSpeed;

        horizontal = 0;
        vertical = 0;

        //define rigidbody
        rb = transform.GetComponent<Rigidbody>();
        //get animator from child
        cameraAnimator = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //set inputs
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        mouseX = Input.GetAxis("Mouse X");

        CharMove();
        CharJump();
        
        //rotate player leftright with mouse input
        transform.Rotate(Vector3.up * mouseX * 360 * Time.deltaTime);

        //set animation parameters
        if(OnGround && vertical != 0)
        {
            cameraAnimator.SetBool("isWalking", true);
        }
        else
        {
            cameraAnimator.SetBool("isWalking", false);
        }
    }

    private void CharMove()
    {
        //run if holding down shift
        if (Input.GetKey("left shift"))
        {
            MoveSpeed = RunningMoveSpeed;
        }
        else
        {
            MoveSpeed = WalkingMoveSpeed;
        }

        //find new movement vector
        Vector3 MovementVector = Vector3.zero;

        MovementVector += transform.forward * vertical;
        MovementVector += transform.right * horizontal;
        MovementVector = MovementVector.normalized * MoveSpeed;

        //set velocity to movement vector
        rb.velocity = new Vector3(MovementVector.x, rb.velocity.y, MovementVector.z);
    }

    private void CharJump()
    {
        if(OnGround && Input.GetKey(KeyCode.Space))
        {
            rb.velocity = new Vector3(rb.velocity.x, JumpHeight, rb.velocity.z);
        }
    }


    //OnGroundChecks
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            OnGround = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            OnGround = false;
        }
    }
}
