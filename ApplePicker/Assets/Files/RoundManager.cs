using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoundManager : MonoBehaviour {
    public Text roundText; // Référence au texte qui affiche le round
    public int currentRound = 1; // Initialiser au premier round
    private ApplePicker applePicker; // Référence au script ApplePicker

    void Start() {
        // Initialisation
        applePicker = FindObjectOfType<ApplePicker>(); // Chercher le script ApplePicker
        UpdateRoundText(); // Mettre à jour le texte du round
    }

    public void UpdateRoundText() {
        roundText.text = "Round " + currentRound; // Mettre à jour l'affichage
    }

    public void NextRound() {
        if (currentRound < 4) { // Il n'y a que 4 rounds
            currentRound++;
            UpdateRoundText(); // Mettre à jour l'affichage pour le nouveau round
        }
    }
}