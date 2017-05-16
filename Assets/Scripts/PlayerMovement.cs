using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public AudioSource sfxAudioPlayer;
    public AudioClip jumpUpSound;
    public AudioClip jumpDownSound;
    public AudioClip gameOverSound;

    public Rigidbody myBody;

    public float rayCastDistance;
    public float maxSpeed;
    public float moveAcceleration;
    public float jumpVelocity;
    public float jumpAcceleration;
    private bool isGrounded = false;
    private bool isGameOver = false;
    public float gameOverHeight = -5f;

    void FixedUpdate()
    {
        GroundChecker();
        ConstantMove();

    }
   
    void Update()
    {
        if(transform.position.y < gameOverHeight && isGameOver == false)
        {
            isGameOver = true;
            sfxAudioPlayer.PlayOneShot(gameOverSound);
        }

        if (isGrounded &&(Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0) ) )

        {
            jump();
        }
        
        Debug.DrawLine(transform.position, transform.position + Vector3.down * rayCastDistance);
    }
    void OnCollisionEnter(Collision collisionInfo)
    {
        //isGrounded = true;
        sfxAudioPlayer.PlayOneShot(jumpDownSound);
    }

    void OnCollisionExit(Collision collisionInfo)
    {
        //isGrounded = false;
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
        sfxAudioPlayer.PlayOneShot(jumpUpSound);
        
    }
    void GroundChecker()
    {
        Ray ray = new Ray();
        ray.origin = transform.position;
        ray.direction = Vector3.down;
        isGrounded = Physics.Raycast(ray, rayCastDistance);
    }
}