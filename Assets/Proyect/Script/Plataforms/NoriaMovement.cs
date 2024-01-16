using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoriaMovement : MonoBehaviour
{
    [SerializeField] private Transform rotationCenter;//Is an Empty whose function is to be the centre of the circle to be traced.
    [SerializeField] private float rotationRadius = 6f, angularSpeed = 1f;//What moves away from the radius of the circumference and the speed at which it moves away from it
    private float posX, posY, angle = 0;

    /// <summary>
    /// In this code fragment, we have a variable that is going to be equal to the real time, 
    /// the variable Angle is going to increase progressively until it reaches 360 and then it 
    /// will return to 0 thanks to the if.
    /// </summary>
     void Update()
     {
        posX = rotationCenter.position.x + Mathf.Cos (angle) * rotationRadius;
        posY = rotationCenter.position.y + Mathf.Sin (angle) * rotationRadius;
        transform.position = new Vector3(posX, posY, 0);
        angle = angle + Time.deltaTime;

        if(angle >= 360f)
        {
        angle = 0f;
        }
     }
}
