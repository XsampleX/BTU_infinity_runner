using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody myBody;
    public float maxSpeed;
    public float moveAcceleration;
    public float jumpVelocity;
    public float jumpAcceleration;
    private bool isGrounded = false;

    void FixedUpdate()
    {
        ConstantMove();

    }
   
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded == true )
        {
            jump();
        }
    }
    void OnCollisionEnter(Collision collisionInfo)
    {

        isGrounded = true;
    }
    void OnCollisionExit(Collision collisionInfo)
    {
        isGrounded = false;
    }
    //void OnCollisionStay(Collision collisionInfo)
    //{
        //isGrounded
    //}

            //this function moves the ballon z axis 
    void ConstantMove()
    {
        //don't move with higher speed than maxSpeed
        Vector3 newVelocity = myBody.velocity;
        if (myBody.velocity.z >= maxSpeed)
        {          
            newVelocity.z = maxSpeed;         
        }
        //accelerate to max speed
        else
        {
            newVelocity.z = newVelocity.z + moveAcceleration;
        }
        myBody.velocity = newVelocity;
    }
    //makes ball jump
     void jump()
    {
        Vector3 jumpVelocity = myBody.velocity;
        jumpVelocity.y = jumpVelocity.y + jumpAcceleration;
        myBody.velocity = jumpVelocity;
    }
}