using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformsMovement : MonoBehaviour
{
    [SerializeField] private Transform locatorA;
    [SerializeField] private Transform locatorB;
    [SerializeField] private float speed = 5f;

    private bool goToB = true;
    
    /// <summary>
    /// Vector3.MoveTowards Moves a point current in a straight line towards a target point.
    /// </summary>
    void Update()
    {
        if (goToB)
        {
            transform.position = Vector3.MoveTowards(transform.position, locatorB.position, speed * Time.deltaTime);

            if (transform.position == locatorB.position)
            {
                goToB = false;
            }
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, locatorA.position, speed * Time.deltaTime);

            if (transform.position == locatorA.position)
            {
                goToB = true;
            }
        }
    }
}