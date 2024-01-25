using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameAssets : MonoBehaviour
{
public static GameAssets Instance { get; private set; }
public GameObject bronceCoin;
public GameObject silverCoin;
public GameObject goldStarCoin;
public GameObject player;
private void Awake()
    {
        // Singleton
        if (Instance != null)
        {
            Debug.LogError("There is more than one Instance");
        }

        Instance = this;
    }
}