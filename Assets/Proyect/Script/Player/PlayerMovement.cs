using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody rigidBody;

    [SerializeField] private float speed = 5f;
    [SerializeField] private float horizontalInput;
    private float jumpForce = 10f;


    [SerializeField]private bool isGrounded;
    private void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(new Vector3(horizontalInput * speed * Time.deltaTime, 0, 0));


        // Jump if you are on the ground and press the jump key
        if (isGrounded && Input.GetKeyDown(KeyCode.Space) || isGrounded && Input.GetKeyDown(KeyCode.W))
        {
            rigidBody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);//From fisics
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
            rigidBody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
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
}