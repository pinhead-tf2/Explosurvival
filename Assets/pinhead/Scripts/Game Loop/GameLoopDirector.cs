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

    // Start is called before the first frame update
    void Start() {
        gameState = validGameStates[1]; // Intermission
        timeLeft = intermissionLength;
        timerActive = true;
    }

    // Update is called once per frame
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
                    Cleanup();
                }
            }
        }
    }

    void SetupPlayspace() { // Possibly make this a game setup director??
        gameState = validGameStates[2]; // Setup
        // do stuff

        // countdown
        GameLoop();
    }

    void GameLoop() {
        // Make bomb and item directors active
        gameState = validGameStates[3];
    }

    void Cleanup() {
        gameState = validGameStates[4];
    }

}
