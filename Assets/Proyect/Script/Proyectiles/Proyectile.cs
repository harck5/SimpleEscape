using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Proyectile : MonoBehaviour
{
    private float timer;
    [SerializeField]private float timerMax;
    private float speed = 5;
    void FixedUpdate()
    {
        transform.Translate(Vector3.up * speed * Time.deltaTime);//goes to the top of the pryectile
        //Timer to destroy the object
        timer += Time.deltaTime;
        if (timer >= timerMax)
        {
            Destroy(gameObject);
        }
    }
}
