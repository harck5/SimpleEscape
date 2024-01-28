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
            // Asegurarse de que la longitud de los arrays es la misma
            if (scenesButtons.Length != scenesLevesName.Length)
            {
                Debug.LogError("La longitud de los arrays de botones y nombres de escenas no coincide.");
                return;
            }

            // Asociar cada botón a su respectiva escena
            for (int i = 0; i < scenesButtons.Length; i++)
            {
                int sceneIndex = i; // Capturar el índice actual para evitar el cierre sobre la variable incorrecta
            scenesButtons[i].onClick.AddListener(() => LoadScene(scenesLevesName[sceneIndex]));
            }
        }

        // Método para cargar una escena
        private void LoadScene(string sceneName)
        {
            SceneManager.LoadScene(sceneName);
        }
}
