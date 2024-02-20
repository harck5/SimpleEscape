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
            GetComponent<Renderer>().material.color = Color.red;//Change color
            SoundManager.Instance.PlaySound(SoundManager.Sound.Lazy);//Sound
            StartCoroutine(WaitAndStartGoingDown());
        }
    }
    private IEnumerator WaitAndStartGoingDown()//timer
    {
        yield return new WaitForSeconds(waitTime);
        goDown = true;
    }
    private void Update()
    {
        if (goDown)//platform falls
        {
            transform.Translate(Vector3.down * speed * Time.deltaTime);
        }
        
    }
}
