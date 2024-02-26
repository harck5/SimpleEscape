using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody rigidBody;

    [SerializeField] private float speed = 5f;
    [SerializeField] private float horizontalInput;
    private float jumpForce = 10f, waitTime = 0.3f;
    ParticleSystem particleJump;
    private bool offParticle;

    public float distanceRay = 0.5f;
    private LayerMask Ground;

    //private float timeInAir;
    //private float heithJump = 4;

    [SerializeField]private bool isGrounded;
    private void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        particleJump = GameObject.Find("Particle System").GetComponent<ParticleSystem>();
        particleJump.transform.parent = transform.transform;

        particleJump.Stop();
    }

    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        //transform.Translate(new Vector3(horizontalInput * speed * Time.deltaTime, 0, 0));
        rigidBody.velocity = new Vector3(horizontalInput * speed, rigidBody.velocity.y, 0);
        //RaycastHit2D rayLeft = Physics2D.Raycast(transform.position, Vector2.left, distanceRay, Ground);
        //Debug.DrawRay(transform.position, Vector2.left, Color.red ,distanceRay);




        // Jump if you are on the ground and press the jump key
        if (isGrounded && Input.GetKeyDown(KeyCode.Space) || isGrounded && Input.GetKeyDown(KeyCode.W))
        {
            rigidBody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);//From fisics
            //Jump();
            SoundManager.Instance.PlaySound(SoundManager.Sound.Jump);//Soun for Jump
            particleJump.Play();
            StartCoroutine(WaitAndStartGoingDown());
        }
        /*if (!isGrounded)
        {
            timeInAir -= Time.deltaTime;

            if (timeInAir <= 0)
            {
                isGrounded = true;
                timeInAir = 2f; // Restart
            }
        }*/

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
            SoundManager.Instance.PlaySound(SoundManager.Sound.Bounce);
        }
    }
    void OnCollisionStay(Collision collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;//Can jump
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
    private IEnumerator WaitAndStartGoingDown()//timer
    {
        yield return new WaitForSeconds(waitTime);
        particleJump.Stop();
    }
    /*void Jump()
    {
        
        float nuevaAltura = transform.position.y + heithJump;
        transform.position = new Vector3(transform.position.x, nuevaAltura, transform.position.z);

        
        isGrounded = false;
    }*/
}