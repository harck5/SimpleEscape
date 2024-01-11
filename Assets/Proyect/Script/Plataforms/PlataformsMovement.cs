using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformsMovement : MonoBehaviour
{
    private Rigidbody plataformRb;
    public Transform locatorA, locatorB;
    public float speed = 1f;

    private bool goToB = true;
    private void Start()
    {
        plataformRb = GetComponent<Rigidbody>();
    }
    /// <summary>
    /// Vector3.MoveTowards Moves a point current in a straight line towards a target point.
    /// </summary>
    void FixedUpdate()
    {
        
        if (goToB)
        {
            MoveTowards(locatorB.position);
            if (Vector3.Distance(plataformRb.position, locatorB.position) < 0.1f)
            {
                goToB = false;
            }
        }
        else
        {
            MoveTowards(locatorA.position);
            if (Vector3.Distance(plataformRb.position, locatorA.position) < 0.1f)
            {
                goToB = true;
            }
        }
    }
    private void MoveTowards(Vector3 targetPosition)
    {
        Vector3 direction = (targetPosition - plataformRb.position).normalized;
        plataformRb.MovePosition(plataformRb.position + direction * speed);
        plataformRb.MovePosition(plataformRb.position + direction * speed * );
    }
}