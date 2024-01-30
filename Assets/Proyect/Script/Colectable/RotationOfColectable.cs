using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationOfColectable : MonoBehaviour
{
    private float speed = 50f;

    void Start()
    {
        StartCoroutine(Rotate());
    }

    IEnumerator Rotate()//no use update
    {
        while (true)
        {
            transform.Rotate(Vector3.up * speed * Time.deltaTime);
            yield return null;//no end
        }
    }
}
