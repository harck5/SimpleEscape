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
    private static int resetScore = 0;

    public static void InitializeStaticScore()
    {
        // Load score
        LoadHighScore();
        ResetScore();
        ScoreUI.Instance.UpdateHighScoreText(highScore);
    }
    public static void AddScore(int pointsToAdd)
    {
        score += pointsToAdd;
        if(score > 0)
        {
            SoundManager.Instance.PlaySound(SoundManager.Sound.Coins);//Sound
        }
        // Update highScore
        if (score > highScore)
        {
            highScore = score;
            SaveHighScore();
            
        }
        ScoreUI.Instance.UpdateScoreText(score);
    }

    public static void ResetHighScore()//Associate the values ??and save the changes to reset the score
    {
        highScore = resetScore;
        PlayerPrefs.SetInt(HIGH_SCORE_KEY, resetScore);
        PlayerPrefs.Save();
        ScoreUI.Instance.UpdateHighScoreText(highScore);
    }
    private static void SaveHighScore()//Associate the values ??and save the changes
    {
        PlayerPrefs.SetInt(HIGH_SCORE_KEY, highScore);
        PlayerPrefs.Save();
    }

    private static void LoadHighScore()//If there is value in HIGH_SCORE_KEY then equal highScore
    {
        if (PlayerPrefs.HasKey(HIGH_SCORE_KEY))
        {
            highScore = PlayerPrefs.GetInt(HIGH_SCORE_KEY);
        }
    }
    public static void ResetScore()//to start the level at 0
    {
        score = 0;
        AddScore(0);
        ScoreUI.Instance.UpdateScoreText(score);//And call visual funtion
    }
}