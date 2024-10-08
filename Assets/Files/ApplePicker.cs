using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ApplePicker : MonoBehaviour{
    [Header("Inscribed")]
    public GameObject   basketPrefab;
    public int          numBaskets = 4;
    public float        basketBottomY = -14f;   
    public float        basketSpacingY = 1.5f;
    public List<GameObject> basketList;
    private ScoreCounter scoreCounter; // Référence au ScoreCounter
    private RoundManager roundManager; // Référence au RoundManager

    void Start() {
        basketList = new List<GameObject>();
        for ( int i=0; i<numBaskets; i++ ) {
            GameObject tBasketGO = Instantiate<GameObject>(basketPrefab);
            Vector3 pos = Vector3.zero;
            pos.y = basketBottomY + (basketSpacingY * i);
            tBasketGO.transform.position = pos;
            basketList.Add( tBasketGO );
        }

        // Trouver et initialiser ScoreCounter
        GameObject scoreGO = GameObject.Find("ScoreCounter");
        if (scoreGO != null) {
            scoreCounter = scoreGO.GetComponent<ScoreCounter>();
        }

        // Trouver et initialiser RoundManager
        roundManager = FindObjectOfType<RoundManager>();
    }

    public void AppleMissed() {
        // Destroy all of the falling Apples
        GameObject[] appleArray=GameObject.FindGameObjectsWithTag("Apple");
        foreach (GameObject tempGO in appleArray) {
            Destroy(tempGO);
        }

        // Destroy one of the Baskets
        // Get the index of the last Basket in basketList
        int basketIndex = basketList.Count-1;
        // Get a reference to that Basket GameObject
        GameObject basketGO = basketList[basketIndex];
        // Remove the Basket from the list and destroy the GameObject
        basketList.RemoveAt(basketIndex);
        Destroy(basketGO);

        // Si le RoundManager existe, passer au round suivant
        if (roundManager != null) {
            roundManager.NextRound(); // Passer au round suivant
        }

        // Sauvegarder le score final si ScoreCounter n'est pas nul
        if (scoreCounter != null) {
            PlayerPrefs.SetInt("FinalScore", scoreCounter.score);
        }

        // Si tous les paniers sont perdus, charger l'écran de Game Over
        if (basketList.Count == 0) {
            SceneManager.LoadScene("GameOverMenu");
        }
    }
}