using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameOverUI : MonoBehaviour
{
    public TextMeshProUGUI gameOverText, gameOverTotalCoins, gameOverTime, gameOverMessage, TotalCoins, timer, restartButtonText;
    public GameObject gameOverPanel;
    public Button restartButton, mainMenuButton;

    private void Start()
    {
        gameOverPanel.SetActive(false);
        if (restartButton != null)
        {
            restartButton.onClick.AddListener(RestartThisScene);
        }
        if(mainMenuButton !=null)
        {
            mainMenuButton.onClick.AddListener(ExitToMenu);
        }
    }
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
        restartButtonText.text = "Restart";
        gameOverMessage.text = ("You Are The Loser");
        gameOverPanel.gameObject.SetActive(true);//Show the panel
    }
    public void RestartThisScene()
    {
        Debug.Log("Entra");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1f;
    }
    public void ExitToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}