using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameOver : MonoBehaviour
{
    public Button      buttonPrefab; 

    private void Start() {
        buttonPrefab.onClick.AddListener(startGame);

        TMP_Text gt = this.GetComponent<TMP_Text>();
        int score = PlayerPrefs.GetInt("Score");
        int HighScore = PlayerPrefs.GetInt("HighScore");
        if (HighScore == score) {
            gt.text = "You beat a high score!\n" + 
                "Game Over: " + score;
        } else {
            gt.text = "Game Over: " + score;
        }
    }

    private void startGame() {
        SceneManager.LoadScene("_Scene_0");
    }
}
