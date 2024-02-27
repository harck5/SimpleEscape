using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject menuPanel, controlsPanel;//panels
    [SerializeField] private Button playButton, controlsButton, settingsButton, exitGameButton, backControlsButton, backSettingsButton;
    private void Awake()
    {
        menuPanel.SetActive(true);
        controlsPanel.SetActive(false);
    }
    private void Start()//add funtions to the buttons
    {
        
        if (playButton != null)
        {
            playButton.onClick.AddListener(LoadLevelsScene);
        }
        if (controlsButton != null)
        {
            controlsButton.onClick.AddListener(ShowControlPanel);
        }
        if (exitGameButton != null)
        {
            exitGameButton.onClick.AddListener(ExitGame);
        }
        if (backControlsButton != null)
        {
            backControlsButton.onClick.AddListener(GoBackControlPanel);
        }
    }

    public void ShowControlPanel()//go control panel
    {
        
        controlsPanel.SetActive(true);
        menuPanel.SetActive(false);
    }
    public void GoBackControlPanel()//Return to menu
    {
        controlsPanel.SetActive(false);
        menuPanel.SetActive(true);
    }

    public void LoadLevelsScene()//load scene of selection levels
    {
        string levels = "Levels";
        SceneManager.LoadScene(levels);
    }
    public void ExitGame()//Stop running the game
    {
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }
}