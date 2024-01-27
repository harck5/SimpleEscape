using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class PauseUi : MonoBehaviour
{
    [SerializeField] private GameObject pausePanel, settingsPanel;
    [SerializeField] private Button resubeButton, restartButton, settingsButton, exitMenuButton, exitGameButton;
    private void Start()
    {
        settingsPanel.SetActive(false);
        if (restartButton != null)
        {
            restartButton.onClick.AddListener(RestartThisScene);
        }
        if (settingsButton != null)
        {
            ShowSettingsPanel();
            pausePanel.SetActive(false);
        }
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // Alternar entre activar y desactivar el pausePanel
            pausePanel.gameObject.SetActive(!pausePanel.gameObject.activeSelf);
            if (pausePanel.gameObject.activeSelf)
            {
                Time.timeScale = 0f;
            }
            if (!pausePanel.gameObject.activeSelf)
            {
                Time.timeScale = 1f;
            }
        }
    }
    public void RestartThisScene()
    {
        Debug.Log("Entra");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1f;
    }
    public void ShowSettingsPanel() 
    {
        if (settingsPanel != null)
        {
            settingsPanel.SetActive(true);
        }
    }
}
