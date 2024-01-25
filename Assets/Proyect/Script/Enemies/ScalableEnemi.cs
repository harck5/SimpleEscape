using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScalableEnemi : MonoBehaviour
{
    private GameObject player;
    [SerializeField] private float distnaceToScale = 5f, maxScale = 3f;
    private Vector3 scaleUp, scaleDown;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player"); //Need to assign yes or yes by code to the player in start
        scaleUp = new Vector3(maxScale, maxScale, maxScale); //Calculate vectors for scaling
        scaleDown = new Vector3(1, 1, 1);
    }

    void Update()
    {
        float distanciaAlPlayer = Vector3.Distance(transform.position, player.transform.position);//Recalculate player position frame by frame
        //And we modify the scale according to the distance it is from the player
        if (distanciaAlPlayer <= distnaceToScale)
        {
            transform.localScale = scaleUp;
        }
        else
        {
            transform.localScale = scaleDown;
        }
    }


}
