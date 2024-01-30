using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SelectionLevels : MonoBehaviour
{
    [SerializeField] private Button[] scenesButtons;
    [SerializeField] private string[] scenesLevesName;
        private void Start()
        {
            if (scenesButtons.Length != scenesLevesName.Length)
            {
                Debug.LogError("arrays botones y nombres escenas no coincide.");
                return;
            }
            for (int i = 0; i < scenesButtons.Length; i++)
            {
                int sceneIndex = i;
            scenesButtons[i].onClick.AddListener(() => LoadScene(scenesLevesName[sceneIndex]));
            }
        }

        
        private void LoadScene(string sceneName)
        {
            SceneManager.LoadScene(sceneName);
            Time.timeScale = 1f; 
        }
}
