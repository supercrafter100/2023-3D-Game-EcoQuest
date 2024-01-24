using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Attach these buttons in the Unity Editor by dragging them into these slots
    [SerializeField] private Button playButton;
    [SerializeField] private Button exitButton;

    private void Start()
    {
        // Add listeners to the buttons
        playButton.onClick.AddListener(PlayGame);
        exitButton.onClick.AddListener(QuitGame);
    }

    public void PlayGame()
    {
        // TODO: Set the correct scene name or index between the parentheses of LoadScene and uncomment
        // SceneManager.LoadScene("YourSceneName");
        Debug.Log("Play Game button clicked");
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quit Game button clicked");
    }

}
