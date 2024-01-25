using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    [SerializeField] private GameObject player;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        transform.parent = player.transform;
    }
}
