using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationOfColectable : MonoBehaviour
{
    private float speed = 100;
    void Start()
    {
        while()
        {
            transform.Rotate(Vector3.up * speed * Time.deltaTime);
        }
    }
}
