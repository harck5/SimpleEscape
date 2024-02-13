using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SoundAssets : MonoBehaviour
{
    public static SoundAssets Instance { get; private set; }

    [SerializeField] private AudioClip audioJump;
private void Awake()//Singleton
    {
        if (Instance != null)
        {
            Debug.LogError("More than one Instance");
        }

        Instance = this;
    }
}
