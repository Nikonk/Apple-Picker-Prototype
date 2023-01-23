using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    public Button      buttonPrefab; 

    void Start() {
        buttonPrefab.onClick.AddListener(startGame);
    }

    private void startGame() {
        SceneManager.LoadScene("_Scene_0");
    }
}
