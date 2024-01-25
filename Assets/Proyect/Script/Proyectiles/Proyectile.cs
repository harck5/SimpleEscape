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
        transform.Translate(Vector3.up * speed * Time.deltaTime);//goes to the top of the proyectile
    }
    private void Start()
    {
        StartCoroutine(TimerRain());
    }

    private IEnumerator TimerRain()
    {
        while (timer < timerMax)
        {
            timer += Time.fixedDeltaTime;
            yield return new WaitForFixedUpdate();
        }

        Destroy(gameObject);//When timer is finish destroy this gameobject
    }
}
