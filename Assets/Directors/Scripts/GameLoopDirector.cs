using TMPro;
using UnityEngine;

namespace Directors
{
    public class GameLoopDirector : MonoBehaviour
    { 
        [Header("Game States")]
        [ReadOnly] public string gameState = "NoState";
        private readonly string[] _validGameStates = new string[] {"NoState", "Intermission", "Setup", "Playing", "Cleanup"};
        [Space(5)]

        [Header("Timer")] // Timer Section
        [Tooltip("The time left in the current intermission or round.")]
        [ReadOnly] public float timeLeft;
        [ReadOnly] public bool timerActive;
        private readonly float _intermissionLength = 30f, _roundLength = 150f; // Length of the intermission, round (seconds)
        [Space(5)]

        [Header("UI")]
        [SerializeField] TextMeshProUGUI timerText;

        // Code

        private void Start() {
            Intermission();
        }

        private void Update() {
            if (timerActive) {
                if (timeLeft > 0) {
                    timeLeft -= Time.deltaTime;
                    // Update UI
                } else {
                    timerActive = false;
                    timeLeft = 0f;
                    if (gameState == _validGameStates[1]) { // Intermission
                        SetupPlayspace();
                    } else if (gameState == _validGameStates[3]) { // Playing
                        EndRound();
                    }
                }
            }
        }

        // Custom Voids

        private void Intermission() {
            gameState = _validGameStates[1]; // Intermission
            timeLeft = _intermissionLength;
            timerActive = true;
        }

        private void SetupPlayspace() { // Possibly make this a game setup director??
            gameState = _validGameStates[2]; // Setup
            // do stuff

            // countdown
            GameLoop();
        }

        private void GameLoop() {
            gameState = _validGameStates[3]; // Playing
            // Make bomb and item directors active
            EndRound();
        }

        private void EndRound() {
            gameState = _validGameStates[4]; // Cleanup

            Intermission();
        }

    }
}
