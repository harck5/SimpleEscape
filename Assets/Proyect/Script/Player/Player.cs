using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player Instance { get; private set; }
    public bool gameOver = false;
    public bool win = false;
    private void Awake()//Singleton
    {
        if (Instance != null)
        {
            Debug.LogError("More than one Instance");
        }

        Instance = this;
    }
    void OnTriggerEnter(Collider other)
    {
        //Ejecutable coins
        if (other.CompareTag("Bronze"))
        {
            Destroy(other.gameObject);
            ScoreManager.AddScore(ScoreManager.BRONZE_COINS);
        }
        if (other.CompareTag("Silver"))
        {
            Destroy(other.gameObject);
            ScoreManager.AddScore(ScoreManager.SILVER_COINS);
        }
        if (other.CompareTag("Gold"))
        {
            Destroy(other.gameObject);
            ScoreManager.AddScore(ScoreManager.GOLD_COINS);
        }
        //Ejecutable enemies GameOver
        if (other.CompareTag("Enemi"))
        {
            Debug.Log("Destroy whith Enemi");
            GameManager.Instance.GameOver();
        }
        if (other.CompareTag("Proyectile"))
        {
            Debug.Log("Destroy whith projectile");
            GameManager.Instance.GameOver();
        }
        //Ejecutable limit GameOver
        if (other.CompareTag("Limit"))
        {
            Debug.Log("Destroy whith limit");
            GameManager.Instance.GameOver();
        }
        //Ejecutable win
        if(other.CompareTag("Win"))
        {
            Debug.Log("Win");
            GameManager.Instance.PlayerWin();
        }
    }
}
