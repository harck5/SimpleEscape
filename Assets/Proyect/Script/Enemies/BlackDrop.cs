using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackDrop : MonoBehaviour
{
    private GameObject player;
    public GameObject blackDrop;
    [SerializeField] private float distnaceToBlackDrop = 5f, timer = 3, timerMax = 3;
    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player"); //Need to assign yes or yes by code to the player in awake
    }
    private void Start()
    {
    }

    void Update()
    {
        float distanciaAlPlayer = Vector3.Distance(transform.position, player.transform.position);//Recalculate player position frame by frame
        //And we modify the scale according to the distance it is from the player
        timer += Time.deltaTime;
        if (timer >= timerMax)
        {
            if (distanciaAlPlayer <= distnaceToBlackDrop)
            {
                Instantiate(blackDrop, transform.position + Vector3.zero, Quaternion.Euler(0, 0, 0));
                Instantiate(blackDrop, transform.position + Vector3.zero, Quaternion.Euler(0, 0, 45));
                Instantiate(blackDrop, transform.position + Vector3.zero, Quaternion.Euler(0, 0, 90));
                Instantiate(blackDrop, transform.position + Vector3.zero, Quaternion.Euler(0, 0, 135));
                Instantiate(blackDrop, transform.position + Vector3.zero, Quaternion.Euler(0, 0, 180));
                Instantiate(blackDrop, transform.position + Vector3.zero, Quaternion.Euler(0, 0, 225));
                Instantiate(blackDrop, transform.position + Vector3.zero, Quaternion.Euler(0, 0, 270));
                Instantiate(blackDrop, transform.position + Vector3.zero, Quaternion.Euler(0, 0, 315));
                timer -= timerMax; // Restart Timer
            }
        }
    }
}
