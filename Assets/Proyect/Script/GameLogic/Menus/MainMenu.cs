using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
      GameObject mainMenu;
    public GameObject controlsPanel;
    public GameObject settingsPanel;
    
    private void Start()
    {
        controlsPanel.SetActive(false);
        settingsPanel.SetActive(false);
    }

    public void ShowControlPanel()
    {
        
        controlsPanel.SetActive(true);
        mainMenu.SetActive(false);
    }

    public void ShowSettingsPanel()
    {
        settingsPanel.SetActive(true);
        mainMenu.SetActive(false);
    }
    public void GoBackSettingsPanel()
    {
        settingsPanel.SetActive(false);
        mainMenu.SetActive(true);

    }
    public void GoBackControlPanel()
    {
        controlsPanel.SetActive(false);
        mainMenu.SetActive(true);
    }

    public void LoadLevelsScene()
    {
        string levels = "Levels";
        SceneManager.LoadScene(levels);
    }
}