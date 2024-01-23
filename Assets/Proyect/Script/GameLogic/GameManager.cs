using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    private void Awake()
{
    // Singleton
    if (Instance != null)
    {
        Debug.LogError("There is more than one Instance");
    }

    Instance = this;
}
    void Start()
    {
        ScoreManager.InitializeStaticScore();//funciona
    }
}
