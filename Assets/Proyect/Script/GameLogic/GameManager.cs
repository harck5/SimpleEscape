using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    [SerializeField] GameObject player;
    private void Awake()
{
    // Singleton
    if (Instance != null)
    {
        Debug.LogError("There is more than one Instance");
    }

    Instance = this;
        
        Instantiate(player, transform.position, Quaternion.identity);//Instantiate player
        
    }

    private void Start()
    {
        ScoreManager.InitializeStaticScore(); // If we call it in awake it will be too early for the game because the functions on which this function depends are not called in awake
    }

    public void GameOver()//GameOver consequences
    {
        Player.Instance.gameOver = true; 
        Time.timeScale = 0f;
    }
    public void PlayerWin()//GameOver consequences
    {
        Player.Instance.win = true; 
        Time.timeScale = 0f;
    }
}
