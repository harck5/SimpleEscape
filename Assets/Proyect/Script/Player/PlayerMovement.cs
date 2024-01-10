using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float force, jumpForce;
    private float xInput;
    private Rigidbody playerRb;
    [SerializeField]private bool isGrounded;

    private void Start()
    {
        playerRb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        if (isGrounded)
        {
            xInput /= 2;
        }
            xInput = Input.GetAxisRaw("Horizontal");
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }
    void FixedUpdate()
    {
        Vector3 input = new Vector3(xInput, 0, 0);
        playerRb.AddForce(input * force);  
    }
    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            //transform.parent = collision.transform;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
            
        }
    }
}