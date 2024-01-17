using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot : MonoBehaviour
{
    public GameObject proyectile;
    private float timer;
    [SerializeField] private float timerMax = 1f;//Modify the height
    public float x = 0;
    private void Update()
    {
        timer += Time.deltaTime;
        if (timer >= timerMax)
        {
            timer -= timerMax; // Restart Timer
            //Indicate the projectile rotated 90º so that it makes the shape of the bullet a little
            Instantiate(proyectile, transform.position + new Vector3(0,x,0), Quaternion.Euler (0, 0, 90));
        }
    }
}
