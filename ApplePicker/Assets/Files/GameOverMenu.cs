using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverMenu : MonoBehaviour {
    public Text scoreText; // Référence au composant Text pour afficher le score

    void Start() {
        // Récupérer le score passé depuis ApplePicker
        int finalScore = PlayerPrefs.GetInt("FinalScore", 0);
        if (scoreText != null) {
            scoreText.text = "Score: " + finalScore.ToString("#,0");
        }
    }

    public void RestartGame() {
        // Recharger la scène du jeu
        SceneManager.LoadScene("_Scene_0");
    }

    public void QuitGame() {
        // Quitter le jeu
        Application.Quit();
        Debug.Log("Quit Game");
    }
}
