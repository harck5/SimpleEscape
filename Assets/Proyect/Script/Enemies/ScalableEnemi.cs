using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScalableEnemi : MonoBehaviour
{
    private GameObject player;
    [SerializeField] private float distnaceToScale = 5f;
    Animator anim;
    bool playerIsClose;


    private void Start()
    {
        
        player = GameObject.FindGameObjectWithTag("Player"); //Need to assign yes or yes by code to the player in start
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        float distanciaAlPlayer = Vector3.Distance(transform.position, player.transform.position);//Recalculate player position frame by frame
        playerIsClose = distanciaAlPlayer <= distnaceToScale;
        

        //And we modify the scale according to the distance it is from the player
        // if (distanciaAlPlayer <= distnaceToScale)
        // {
        //     //anim.SetInteger("ScalableAnimationList", 1);
        //     anim.SetBool("Prueba", true);
        //     Debug.Log("Cerca");
        // }
        // else
        // {
        //     anim.SetBool("Prueba", false);
        //     //anim.SetInteger("ScalableAnimationList", 3);
        //     Debug.Log("Lejos");
        // }
    }

    private void LateUpdate()
    {
        anim.SetBool("Prueba", playerIsClose);
        if(playerIsClose)
        {
            SoundManager.Instance.PlaySound(SoundManager.Sound.Scale);//no funciona bien
        }
    }
}
