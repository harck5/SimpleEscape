using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class PauseUi : MonoBehaviour
{
    [SerializeField] private GameObject pausePanel, settingsPanel;
    [SerializeField] private Button resumeButton, restartButton, exitMenuButton, exitGameButton;
    private void Start()//Register functions to buttons
    {
        pausePanel.SetActive(false);
        settingsPanel.SetActive(false);
        if (resumeButton != null)
        {
            resumeButton.onClick.AddListener(ResumeGame);
        }
        if (restartButton != null)
        {
            restartButton.onClick.AddListener(RestartThisScene);
        }
        if (exitMenuButton != null)
        {
            exitMenuButton.onClick.AddListener(ExitToMenu);
        }
        if (exitGameButton != null)
        {
            exitGameButton.onClick.AddListener(ExitGame);
        }
    }
    /// <summary>
    /// Can enter and go out in pausePanel 
    /// Can modify the timescale
    /// Whit the same key
    /// </summary>
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // Toggle between turning pausePanel on and off
            pausePanel.gameObject.SetActive(!pausePanel.gameObject.activeSelf);
            if (pausePanel.gameObject.activeSelf)
            {
                Time.timeScale = 0f;
                settingsPanel.SetActive(false);
            }
            if (!pausePanel.gameObject.activeSelf)
            {
                Time.timeScale = 1f;
            }
        }
    }
    /// <summary>
    /// Hide pausePanel
    /// </summary>
    public void ResumeGame()
    {
        pausePanel.SetActive(false);
        Time.timeScale = 1f;
    }
    /// <summary>
    /// Load this Scene
    /// </summary>
    public void RestartThisScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1f;
    }
    /// <summary>
    /// //Load concrete scene
    /// </summary>
    public void ExitToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    /// <summary>
    /// ExitGame
    /// </summary>
    public void ExitGame()//
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;//If we are in the editor, the game will stop running
        #else//If we are in the already built game it closes
            Application.Quit();
        #endif
    }
}
