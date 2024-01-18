using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private float jumpForce = 80f;

    private bool isGrounded;

    void Update()
    {
        // Movement whith transform
        float horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(new Vector3(horizontalInput * speed * Time.deltaTime, 0, 0));

        // Jump if you are on the ground and press the jump key
        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            GetComponent<Rigidbody>().AddForce(Vector3.up * jumpForce, ForceMode.Impulse);//From fisics
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
        if(collision.gameObject.CompareTag("BouncyGround"))
        {
            //It is the same line that uses space to jump
            GetComponent<Rigidbody>().AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
        if (collision.gameObject.CompareTag("RotatingGround"))
        {
            isGrounded = true;//Can jump
        }
    }
    void OnCollisionStay(Collision collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;//Can jump
        }
        if (collision.gameObject.CompareTag("RotatingGround"))
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
        if (collision.gameObject.CompareTag("RotatingGround"))
        {
            isGrounded = false;//Can't jump
        }
    }
}