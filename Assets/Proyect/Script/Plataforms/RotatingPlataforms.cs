using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingPlataforms : MonoBehaviour
{

    private float angle = 0, currentTime;
    public float speed = 5;

    void Update()
    {
        currentTime = Time.time;
        angle = currentTime;
        transform.Rotate(Vector3.forward * speed / 10);

        if (angle >= 360f)
        {
            angle = 0f;
        }
    }
}
