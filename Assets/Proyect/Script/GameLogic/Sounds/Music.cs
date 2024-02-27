using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour
{
    public AudioSource audioSource;

    void Start()
    {
        if (audioSource != null)
        {
            audioSource.loop = true;
            audioSource.Play();
        }
        else
        {
            Debug.LogError("AudioSource no asignado al script.");
        }
    }
}
