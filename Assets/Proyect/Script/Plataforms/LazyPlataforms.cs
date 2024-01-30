using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LazyPlataforms : MonoBehaviour
{
    private bool goDown = false;
    [SerializeField] private float speed = 5f, waitTime = 0.5f;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player") && !goDown)
        {
            GetComponent<Renderer>().material.color = Color.red;
            StartCoroutine(WaitAndStartGoingDown());
        }
    }
    private IEnumerator WaitAndStartGoingDown()
    {
        yield return new WaitForSeconds(waitTime);
        goDown = true;
    }
    private void Update()
    {
        if (goDown)
        {
            transform.Translate(Vector3.down * speed * Time.deltaTime);
        }
        
    }
}
