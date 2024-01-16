using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LazyPlataforms : MonoBehaviour
{
    private bool goDown = false;
    [SerializeField] private float speed = 5f;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player") && !goDown)
        {
            GetComponent<Renderer>().material.color = Color.red;
            goDown = true;
        }
    }
    private void Update()
    {
        if (goDown)
        {
            transform.Translate(Vector3.down * speed * Time.deltaTime);
        }
        
    }
}
