using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour {
    public void PlayGame() {
        // Charger la scène du jeu
        SceneManager.LoadScene("_Scene_0");
    }

    public void QuitGame() {
        // Quitter le jeu
        Application.Quit();
        Debug.Log("Quit Game");
    }
}
