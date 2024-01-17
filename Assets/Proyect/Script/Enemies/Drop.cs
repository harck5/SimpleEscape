using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drop : MonoBehaviour
{
    public GameObject proyectile;
    private float timer;
    [SerializeField] private float timerMax = 1f;
    [SerializeField] private float heightToDrop = 0; //just in case you have to vary the height
    private void FixedUpdate()
    {
        timer += Time.deltaTime;
        if (timer >= timerMax)
        {
            timer -= timerMax; // The timer is reset
            Instantiate(proyectile, transform.position + new Vector3(0, heightToDrop, 0), Quaternion.identity);//instantiate the drop
        }
    }
}
