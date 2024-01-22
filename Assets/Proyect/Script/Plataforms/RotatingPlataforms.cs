using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingPlataforms : MonoBehaviour
{
    [SerializeField] private float speed = 5;//Don t workikng
    void Start()
    {
        StartCoroutine(RotateContinuously());
    }

    IEnumerator RotateContinuously()
    {
        while (true)
        {
            transform.rotation *= Quaternion.Euler(0, speed * Time.fixedDeltaTime, 0);
            yield return null;
        }
    }
}
