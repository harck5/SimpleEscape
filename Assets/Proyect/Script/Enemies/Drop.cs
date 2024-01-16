using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drop : MonoBehaviour
{
    public GameObject proyectile;
    private float timer;
    [SerializeField] private float timerMax = 1f;
    [SerializeField] private float heightToDrop = 0;
    private void Update()
    {
        timer += Time.deltaTime;
        if (timer >= timerMax)
        {
            timer -= timerMax; // Se reinicia el temporizador
            Instantiate(proyectile, transform.position + new Vector3(0, heightToDrop, 0), Quaternion.identity);
        }
    }
}
