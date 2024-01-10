using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingPlataforms : MonoBehaviour
{
    public float torque = 50f;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        rb.AddTorque(Vector3.forward * torque * 100);
    }
}
