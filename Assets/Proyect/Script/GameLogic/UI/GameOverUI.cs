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
    private bool firstTime;

    private void Start()//Don' Show the panel
    {
        gameOverPanel.SetActive(false);
        if (restartButton != null)//Click button
        {
            restartButton.onClick.AddListener(RestartThisScene);//button run funtion
        }
        if(mainMenuButton !=null)//Click button
        {
            mainMenuButton.onClick.AddListener(ExitToMenu);//button run funtion
        }
        firstTime = true;
    }
    void Update()
    {
        if (Player.Instance.gameOver && firstTime)//firstTime is a variable that is used to prevent the sound from exploding.
        {
            ShowGameOverPanel();//Call function
            firstTime = false;
        }

    }
    void ShowGameOverPanel()//All texts be change
    {
        SoundManager.Instance.PlaySound(SoundManager.Sound.GameOver);
        gameOverText.text = "Game Over";
        gameOverTime.text = timer.text;
        gameOverTotalCoins.text = TotalCoins.text;
        restartButtonText.text = "Restart";
        gameOverMessage.text = ("You Are The Loser");
        gameOverPanel.gameObject.SetActive(true);//Show the panel
    }
    public void RestartThisScene()//"Restart" scene
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);//load scenes (.name) is this scene
        Time.timeScale = 1f;//and return to normal time scale
    }
    public void ExitToMenu()//Load scene MainMenu
    {
        SceneManager.LoadScene("MainMenu");
    }
}