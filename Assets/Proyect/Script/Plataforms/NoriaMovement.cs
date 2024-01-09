using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoriaMovement : MonoBehaviour
{
    public Transform rotationCenter;
    float rotationRadius = 6f, angularSpeed = 1f;
    float posX, posY, angle = 0;


     void Start()
     {

     }
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
