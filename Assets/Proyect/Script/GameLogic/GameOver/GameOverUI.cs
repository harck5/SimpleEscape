using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameOverUI : MonoBehaviour
{
    public TextMeshProUGUI gameOverText, gameOverTotalCoins, TotalCoins, gameOverTime, timer, gameOverMessage, restartButtonText;
    public GameObject gameOverPanel;
    public Button restartButton;

    void Update()
    {
        if (Player.Instance.gameOver)
        {
            ShowGameOverPanel();
        }
    }
    void ShowGameOverPanel()
    {
        gameOverText.text = "Game Over";
        gameOverTime.text = timer.text;
        gameOverTotalCoins.text = TotalCoins.text;
        gameOverMessage.text = ("You Are Loser");
        gameOverPanel.gameObject.SetActive(true);//Show the panel
    }
}