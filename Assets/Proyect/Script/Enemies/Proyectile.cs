using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Proyectile : MonoBehaviour
{
    public float timer;
    public float timerMax;
    private float speed = 5;
    void Update()
    {
        transform.Translate(Vector3.up * speed * Time.deltaTime);
        timer += Time.deltaTime;
        if (timer >= timerMax)
        {
            Destroy(gameObject);
        }
    }
}
