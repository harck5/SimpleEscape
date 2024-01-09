using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvertNoriaMovement : MonoBehaviour
{
    public Transform rotationCenter;//Is an Empty whose function is to be the centre of the circle to be traced.
    public float rotationRadius = 4f, angularSpeed = 10f;//What moves away from the radius of the circumference and the speed at which it moves away from it
    private float posX, posY, angle = 0, currentTime;
    /// <summary>
    /// In this code fragment, we have a variable that is going to be equal to the real time, 
    /// the variable Angle is going to increase progressively until it reaches 360 and then it 
    /// will return to 0 thanks to the if.
    /// </summary>
    void Update()
    {
        currentTime = Time.time;
        angle = currentTime * angularSpeed / 10;
        angle *= -1;
        posX = rotationCenter.position.x + Mathf.Cos(angle) * rotationRadius;
        posY = rotationCenter.position.y + Mathf.Sin(angle) * rotationRadius;
        transform.position = new Vector3(posX, posY, 0);

        if (angle >= -360f)
        {
            angle = 0f;
        }
    }
}
