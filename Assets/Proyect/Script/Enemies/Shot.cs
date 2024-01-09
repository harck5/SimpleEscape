using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot : MonoBehaviour
{
    public GameObject proyectile;
    public float timer;
    private float timerMax = 1f;
    public float x = 0;
    private void Update()
    {
        timer += Time.deltaTime;
        if (timer >= timerMax)
        {
            timer -= timerMax; // Se reinicia el temporizador
            Instantiate(proyectile, transform.position + new Vector3(0,x,0), Quaternion.Euler (0, 0, 90));
        }
    }
}
