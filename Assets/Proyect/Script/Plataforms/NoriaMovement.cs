using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoriaMovement : MonoBehaviour
{
    [SerializeField] private Transform rotationCenter;//Is an Empty whose function is to be the centre of the circle to be traced.
    [SerializeField] private float rotationRadius = 6f, angularSpeed = 10f;//What moves away from the radius of the circumference
    private float posX, posY, angle = 0, currentTime;

    /// <summary>
    /// In this code fragment, we have a variable that is going to be equal to the real time, 
    /// the variable Angle is going to increase progressively
    /// </summary>
    private void Start()
    {
        StartCoroutine(NormalNoria());
    }
    IEnumerator NormalNoria()
    {
        while (true)
        {
            currentTime = Time.time;
            angle = currentTime * angularSpeed / 10;
            posX = rotationCenter.position.x + Mathf.Cos(angle) * rotationRadius;
            posY = rotationCenter.position.y + Mathf.Sin(angle) * rotationRadius;
            transform.position = new Vector3(posX, posY, 0);
            angle = angle + Time.deltaTime;

            yield return null;
        }
    }
}
