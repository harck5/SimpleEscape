using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContraRotatingPlataforms : MonoBehaviour
{
    [SerializeField] private float speed = 5;
    void FixedUpdate()
    {
        transform.Rotate(Vector3.forward * -speed);
    }
}
