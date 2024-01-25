using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvertNoriaMovement : MonoBehaviour
{
    [SerializeField] private Transform rotationCenter;//Is an Empty whose function is to be the centre of the circle to be traced.
    [SerializeField] private float rotationRadius = 4f, angularSpeed = 10f;//What moves away from the radius of the circumference and the speed at which it moves away from it
    private float posX, posY, angle = 0, currentTime;
    /// <summary>
    /// In this code fragment, we have a variable that is going to be equal to the real time, 
    /// the variable Angle is going to increase progressively
    /// </summary>
    private void Start()
    {
        StartCoroutine(InvertNoria());
    }
    IEnumerator InvertNoria()
    {
        while (true)
        {
            currentTime = Time.time;
            angle = currentTime * angularSpeed / 10;
            angle *= -1;
            posX = rotationCenter.position.x + Mathf.Cos(angle) * rotationRadius;
            posY = rotationCenter.position.y + Mathf.Sin(angle) * rotationRadius;
            transform.position = new Vector3(posX, posY, 0);

            yield return null;
        }
    }
}
