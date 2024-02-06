using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pruebas : MonoBehaviour
{
        private float horizontalInput;
    private float speed = 8f;
    private bool canMove;
    private float playerRadius = 0.5f;
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        float moveDistance = speed * Time.deltaTime * horizontalInput;
        //canMove = !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * playerRadius, playerRadius, transform.right, moveDistance);

        canMove = !Physics.Raycast(transform.position, Vector3.right * horizontalInput, playerRadius + moveDistance);
        Debug.Log(canMove);
        //Dibujar el rayo
        if (canMove) { transform.Translate(Vector3.right * moveDistance); }
    }
}
