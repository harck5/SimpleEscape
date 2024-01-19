using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trace : MonoBehaviour
{
    private float timer;
    [SerializeField] private float timerMax = 1.5f;
    void FixedUpdate()//When timer is finish destroy this gameobject
    {
        timer += Time.deltaTime;
        if (timer >= timerMax)
        {
            Destroy(gameObject);
        }
    }
}
