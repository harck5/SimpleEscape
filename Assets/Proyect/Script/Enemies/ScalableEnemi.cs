using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScalableEnemi : MonoBehaviour
{
    private GameObject player;
    [SerializeField] private float distnaceToScale = 5f;
    Animator anim;
    bool playerIsClose;
    bool firstTime;


    private void Start()
    {
        
        player = GameObject.FindGameObjectWithTag("Player"); //Need to assign yes or yes by code to the player in start
        anim = GetComponent<Animator>();

    }

    void Update()
    {
        float distanciaAlPlayer = Vector3.Distance(transform.position, player.transform.position);//Recalculate player position frame by frame
        playerIsClose = distanciaAlPlayer <= distnaceToScale;
    }

    private void LateUpdate()
    {
        anim.SetBool("Prueba", playerIsClose);
        if(playerIsClose && firstTime)
        {
            SoundManager.Instance.PlaySound(SoundManager.Sound.Scale);//no funciona bien
            firstTime = false;
        }
        if(!playerIsClose)
        {
            firstTime = true;
        }
    }
}
