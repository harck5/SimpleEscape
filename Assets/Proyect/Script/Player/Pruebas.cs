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
        

        canMove = !Physics.Raycast(transform.position, Vector3.right, playerRadius + moveDistance) &&
                  !Physics.Raycast(transform.position, Vector3.left, playerRadius - moveDistance);
        if (Input.GetKeyDown(KeyCode.LeftShift)) { speed = 7; }
        if (Input.GetKeyUp(KeyCode.LeftShift)) { speed = 5; }
        canJump = !Physics.Raycast(transform.position, Vector3.down, playerRadius + 0.1f);
        Debug.Log(canJump);
        if (canMove) { transform.Translate(Vector3.right * moveDistance); }
        if(!canJump && Input.GetKeyDown(KeyCode.Space)) { playerRigidbody.AddForce(Vector3.up * jumpSpeed, ForceMode.Impulse); }
    }
}
