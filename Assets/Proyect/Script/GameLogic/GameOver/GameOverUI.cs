using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameOverUI : MonoBehaviour
{
    public TextMeshProUGUI gameOverText, gameOverTotalCoins, TotalCoins, gameOverTime, timer, gameOverMessage;
    public GameObject gameOverPanel;

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
        gameOverPanel.gameObject.SetActive(true);
    }
}