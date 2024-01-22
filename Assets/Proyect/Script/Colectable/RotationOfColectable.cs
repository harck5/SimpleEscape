using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationOfColectable : MonoBehaviour
{
    public float speed = 50f; // Puedes ajustar la velocidad en el Editor de Unity

    void Start()
    {
        StartCoroutine(Rotate());
    }

    IEnumerator Rotate()
    {
        while (true)
        {
            transform.Rotate(Vector3.up * speed * Time.deltaTime);
            yield return null;
        }
    }
}
