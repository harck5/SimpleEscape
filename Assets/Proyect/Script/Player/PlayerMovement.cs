using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody rigidBody;

    [SerializeField] private float speed = 5f;//speed of player
    [SerializeField] private float horizontalInput;//movement input player
    private float jumpForce = 10f, 
    waitTime = 0.3f;//run time of particles
    ParticleSystem particleJump;

    [SerializeField]private bool isGrounded;
    private void Start() //prepare rigidbody and particle system
    {
        rigidBody = GetComponent<Rigidbody>();
        particleJump = GameObject.Find("Particle System").GetComponent<ParticleSystem>();
        particleJump.transform.parent = transform.transform;
        particleJump.Stop();
    }

    void Update()//Basic moumente player
    {
        horizontalInput = Input.GetAxis("Horizontal");
        rigidBody.velocity = new Vector3(horizontalInput * speed, rigidBody.velocity.y, 0);

        if (isGrounded && Input.GetKeyDown(KeyCode.Space) || isGrounded && Input.GetKeyDown(KeyCode.W))
        {
            rigidBody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);//From fisics
            SoundManager.Instance.PlaySound(SoundManager.Sound.Jump);//Sound for Jump
            particleJump.Play();
            StartCoroutine(WaitAndStartGoingDown());//Run corutine to wait 0,5 secs to stop run particles sistem
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            ScoreManager.ResetHighScore();
        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            speed = 7;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            speed = 5;
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;//Can jump
            //Parent the player to the platform, in case it is necessary for the player to follow the movement of the platforms
            transform.parent = collision.transform;
        }
        if (collision.gameObject.CompareTag("BouncyGround"))
        {
            rigidBody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);//From fisics
            SoundManager.Instance.PlaySound(SoundManager.Sound.Bounce);//Sound
        }
    }
    void OnCollisionStay(Collision collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;//Can jump
            transform.parent = collision.transform;
        }
    }
    void OnCollisionExit(Collision collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;//Can't jump
            transform.parent = null;//Unparent the player to plataform
        }
    }
    private IEnumerator WaitAndStartGoingDown()//timer to particle system
    {
        yield return new WaitForSeconds(waitTime);
        particleJump.Stop();
    }
}