using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject menuPanel, controlsPanel, settingsPanel;
    [SerializeField] private Button playButton, controlsButton, settingsButton, exitGameButton, backControlsButton, backSettingsButton;
    private void Awake()
    {
        menuPanel.SetActive(true);
        controlsPanel.SetActive(false);
        settingsPanel.SetActive(false);
    }
    private void Start()
    {
        
        if (playButton != null)
        {
            playButton.onClick.AddListener(LoadLevelsScene);
        }
        if (controlsButton != null)
        {
            controlsButton.onClick.AddListener(ShowControlPanel);
        }
        if (settingsButton != null)
        {
            settingsButton.onClick.AddListener(ShowSettingsPanel);
        }
        if (exitGameButton != null)
        {
            exitGameButton.onClick.AddListener(ExitGame);
        }
        if (backSettingsButton != null)
        {
            backSettingsButton.onClick.AddListener(GoBackSettingsPanel);
        }
        if (backControlsButton != null)
        {
            backControlsButton.onClick.AddListener(GoBackControlPanel);
        }
    }

    public void ShowControlPanel()
    {
        
        controlsPanel.SetActive(true);
        menuPanel.SetActive(false);
    }

    public void ShowSettingsPanel()
    {
        settingsPanel.SetActive(true);
        menuPanel.SetActive(false);
    }
    public void GoBackSettingsPanel()
    {
        settingsPanel.SetActive(false);
        menuPanel.SetActive(true);
    }
    public void GoBackControlPanel()
    {
        controlsPanel.SetActive(false);
        menuPanel.SetActive(true);
    }

    public void LoadLevelsScene()
    {
        string levels = "Levels";
        SceneManager.LoadScene(levels);
    }
    public void ExitGame()
    {
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }
}