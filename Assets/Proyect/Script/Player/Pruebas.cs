using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Pruebas : MonoBehaviour
{
    [SerializeField]private Rigidbody playerRigidbody;
        private float horizontalInput;
    private float speed = 8f;
    private bool canMove, canJump;
    private float playerRadius = 0.5f;
    private float jumpSpeed = 200;

    [SerializeField] private AudioSource _AudioSource;
    [SerializeField] private AudioClip audioJump;
    void Awake()
    {
        playerRigidbody = GetComponent<Rigidbody>();
        _AudioSource = GetComponent<AudioSource>();
    }
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        float moveDistance = speed * Time.deltaTime * horizontalInput;
        //canMove = !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * playerRadius, playerRadius, transform.right, moveDistance);
        

        canMove = !Physics.Raycast(transform.position, Vector3.right, playerRadius + moveDistance, LayerMask.NameToLayer("Ignore Raycast")) &&
                  !Physics.Raycast(transform.position, Vector3.left, playerRadius - moveDistance, LayerMask.NameToLayer("Ignore Raycast"));
        if (Input.GetKeyDown(KeyCode.LeftShift)) { speed = 7; }
        if (Input.GetKeyUp(KeyCode.LeftShift)) { speed = 5; }
        canJump = !Physics.Raycast(transform.position, Vector3.down, playerRadius + 0.1f);
        Debug.Log(canJump);
        if (canMove) { transform.Translate(Vector3.right * moveDistance); }
        if(!canJump && Input.GetKeyDown(KeyCode.Space)) { playerRigidbody.AddForce(Vector3.up * jumpSpeed, ForceMode.Impulse); }
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            canJump = false;//Can jump
            //Parent the player to the platform, in case it is necessary for the player to follow the movement of the platforms
            transform.parent = collision.transform;
        }
        if (collision.gameObject.CompareTag("BouncyGround"))
        {
            //It is the same line that uses space to jump
            playerRigidbody.AddForce(Vector3.up * jumpSpeed, ForceMode.Impulse);
        }
        if (collision.gameObject.CompareTag("RotatingGround"))
        {
            canJump = false;//Can jump
        }
    }
    void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            canJump = false;//Can jump
        }
    }
    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            canJump = true;//Can't jump
            transform.parent = null;//Unparent the player to plataform
        }
    }
}
