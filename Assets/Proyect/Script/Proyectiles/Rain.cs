using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rain : MonoBehaviour
{
    private float timer;
    [SerializeField]private float timerMax = 5f;
    private float speed = 5;
    /// <summary>
    /// Goes down all the time until the timer runs out
    /// </summary>
    void FixedUpdate()
    {
        transform.Translate(Vector3.down * speed * Time.deltaTime);
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
