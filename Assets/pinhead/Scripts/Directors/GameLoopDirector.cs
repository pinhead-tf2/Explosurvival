using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameLoopDirector : MonoBehaviour
{ 
    [Header("Game States")]
    [ReadOnly] public string gameState = "NoState";
    private string[] validGameStates = new string[] {"NoState", "Intermission", "Setup", "Playing", "Cleanup"};
    [Space(5)]

    [Header("Timer")] // Timer Section
    [Tooltip("The time left in the current intermission or round.")]
    [ReadOnly] public float timeLeft;
    [ReadOnly] public bool timerActive = false;
    private float intermissionLength = 30f; // Length of the intermission (seconds)
    private float roundLength = 150f; // Length of a round (seconds)
    [Space(5)]

    [Header("UI")]
    [SerializeField] TextMeshProUGUI timerText;

    // Code

    void Start() {
        Intermission();
    }

    void Update() {
        if (timerActive) {
            if (timeLeft > 0) {
                timeLeft -= Time.deltaTime;
                // Update UI
            } else {
                timerActive = false;
                timeLeft = 0f;
                if (gameState == validGameStates[1]) { // Intermission
                    SetupPlayspace();
                } else if (gameState == validGameStates[3]) { // Playing
                    EndRound();
                }
            }
        }
    }

    // Custom Voids

    void Intermission() {
        gameState = validGameStates[1]; // Intermission
        timeLeft = intermissionLength;
        timerActive = true;
    }

    void SetupPlayspace() { // Possibly make this a game setup director??
        gameState = validGameStates[2]; // Setup
        // do stuff

        // countdown
        GameLoop();
    }

    void GameLoop() {
        gameState = validGameStates[3]; // Playing
        // Make bomb and item directors active
        EndRound();
    }

    void EndRound() {
        gameState = validGameStates[4]; // Cleanup

        Intermission();
    }

}
