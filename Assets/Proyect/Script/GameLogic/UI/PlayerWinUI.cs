using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerWinUI : MonoBehaviour
{
    public TextMeshProUGUI winnerText, winnerTotalCoins, winnerTime, winnerMessage, TotalCoins, timer, restartButtonText;
    public GameObject winnerPanel;
    public Button restartButton, mainMenuButton, selectionLevels;
        private void Start()
    {
        winnerPanel.SetActive(false);
        if (restartButton != null)
        {
            restartButton.onClick.AddListener(RestartThisScene);
        }
        if(mainMenuButton !=null)
        {
            mainMenuButton.onClick.AddListener(ExitToMenu);
        }
        if(selectionLevels !=null)
        {
            selectionLevels.onClick.AddListener(LoadLevelsScene);
        }
    }
    void Update()
    {
        if (Player.Instance.win)
        {
            ShowWinPanel();
        }

    }
    void ShowWinPanel()
    {
        winnerText.text = "You Are The Winner";
        winnerTime.text = timer.text;
        winnerTotalCoins.text = TotalCoins.text;
        restartButtonText.text = "Restart";
        winnerMessage.text = ("Congratulations");
        winnerPanel.gameObject.SetActive(true);//Show the panel
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
    public void LoadLevelsScene()
    {
        string levels = "Levels";
        SceneManager.LoadScene(levels);
    }
}