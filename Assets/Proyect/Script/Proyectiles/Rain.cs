using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rain : MonoBehaviour
{
    private float timer;
    [SerializeField]private float timerMax;
    private float speed = 5;
    void Update()
    {
        transform.Translate(Vector3.down * speed * Time.deltaTime);
        timer += Time.deltaTime;
        if (timer >= timerMax)
        {
            Destroy(gameObject);
        }
    }
}
