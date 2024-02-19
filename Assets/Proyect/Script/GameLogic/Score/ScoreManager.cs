using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public const int BRONZE_COINS = 10;
    public const int SILVER_COINS = 100;
    public const int GOLD_COINS = 1000;

    private const string PLAYER_SCORE_KEY = "PlayerScore";
    private const string HIGH_SCORE_KEY = "HighScore";

    private static int score;
    private static int highScore;

    public static void InitializeStaticScore()
    {
        // Cargar el puntaje almacenado
        LoadScore();
        LoadHighScore();
        ResetScore();
        ScoreUI.Instance.UpdateHighScoreText(highScore);
    }

    public static int GetScore()
    {
        return score;
    }

    public static void AddScore(int pointsToAdd)
    {
        score += pointsToAdd;

        // Actualizar el récord si el puntaje actual supera el récord actual
        if (score > highScore)
        {
            highScore = score;
            SaveHighScore();
        }

        ScoreUI.Instance.UpdateScoreText(score);
        SaveScore();
    }

    public static int GetHighScore()//no se exactamente para que sirve
    {
        return highScore;
    }

    private static void SaveScore()
    {
        PlayerPrefs.SetInt(PLAYER_SCORE_KEY, score);
        PlayerPrefs.Save();
    }

    private static void LoadScore()
    {
        if (PlayerPrefs.HasKey(PLAYER_SCORE_KEY))
        {
            score = PlayerPrefs.GetInt(PLAYER_SCORE_KEY);
        }
    }

    private static void SaveHighScore()
    {
        PlayerPrefs.SetInt(HIGH_SCORE_KEY, highScore);
        PlayerPrefs.Save();
    }

    private static void LoadHighScore()
    {
        if (PlayerPrefs.HasKey(HIGH_SCORE_KEY))
        {
            highScore = PlayerPrefs.GetInt(HIGH_SCORE_KEY);
        }
    }
    public static void ResetHighScore()
    {
        highScore = 0;
        Debug.Log("Restart 2");
    }
    public static void ResetScore()
    {
        score = 0;
        AddScore(0);
        ScoreUI.Instance.UpdateScoreText(score);
    }
}