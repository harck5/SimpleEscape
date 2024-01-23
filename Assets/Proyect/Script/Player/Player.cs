using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
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
    }
}
