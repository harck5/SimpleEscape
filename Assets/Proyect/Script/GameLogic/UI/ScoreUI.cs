using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreUI : MonoBehaviour
{
    public static ScoreUI Instance { get; private set; }

    [SerializeField] private TextMeshProUGUI scoreText, highScoreText;
    
    private void Awake()//Singleton
    {
        if (Instance != null)
        {
            Debug.LogError("More than one Instance");
        }

        Instance = this;
    }   
        public void UpdateScoreText(int score)//Update de scoretext
    {
        Debug.Log(scoreText);
        scoreText.text = $"{score}";
    }
    public void UpdateHighScoreText(int highScore)//Update de scoretext
    {
        highScoreText.text = $"{highScore}";
    }
}