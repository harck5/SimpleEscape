using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public const int BRONZE_COINS = 10;
    public const int SILVER_COINS = 100;
    public const int GOLD_COINS = 1000;
    public static int score;
    //private int totalPoints = 0;
    
    public static void InitializeStaticScore()
    {
        score = 0;
        AddScore(0);
        ScoreUI.Instance.UpdateScoreText(score);
    }

    public static int GetScore()//investigar que es esto
    {
        return score;
    }

    public static void AddScore(int pointsToAdd)
    {
        score += pointsToAdd;
        Debug.Log($"{score}");
        ScoreUI.Instance.UpdateScoreText(score);
    }
}