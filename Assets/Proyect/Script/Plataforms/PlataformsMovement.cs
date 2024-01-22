using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformsMovement : MonoBehaviour
{
    [SerializeField] private Transform locatorA;
    [SerializeField] private Transform locatorB;
    private float speed = 4f;

    private bool goToB = true;
    void Start()
    {
        StartCoroutine(MoveBetweenLocators());
    }

    IEnumerator MoveBetweenLocators()
    {
        while (true)
        {
            if (goToB)//When goToB is true go to locatorB
            {
                //Vector3.MoveTowards Moves a point current in a straight line towards a target point.
                transform.position = Vector3.MoveTowards(transform.position, locatorB.position, speed * Time.deltaTime);

                if (transform.position == locatorB.position)
                {
                    goToB = false;
                }
            }
            else//When goToB is false enter on else
            {
                transform.position = Vector3.MoveTowards(transform.position, locatorA.position, speed * Time.deltaTime);

                if (transform.position == locatorA.position)
                {
                    goToB = true;
                }
            }

            yield return null;
        }
    }
}