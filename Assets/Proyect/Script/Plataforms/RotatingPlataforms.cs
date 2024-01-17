using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingPlataforms : MonoBehaviour
{
    [SerializeField] private float speed = 5;//Don t workikng
    void FixedUpdate()
    {
        
        transform.rotation *= Quaternion.Euler(0, speed * Time.deltaTime, 0);
    }
}
