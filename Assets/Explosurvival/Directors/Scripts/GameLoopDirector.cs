using UnityEngine;
using Explosurvival.UI;
using UnityEngine.Serialization;

namespace Explosurvival.Directors
{
    public class GameLoopDirector : MonoBehaviour
    { 
        [Header("Game States")]
        [SerializeField] private string gameState = "NoState";
        private readonly string[] _validGameStates = new string[] {"NoState", "Intermission", "Setup", "Playing", "Cleanup"};
        [Space(5)]

        [Header("Timer")] // Timer Section
        [Tooltip("The time left in the current intermission or round.")]
        [SerializeField] private float timeLeft;
        [SerializeField] private float startTimeAmount;
        [SerializeField] private bool timerActive;
        public bool TimerActive => timerActive;
        private readonly float _intermissionLength = 30f, _roundLength = 150f; // Length of the intermission, round (seconds)
        [FormerlySerializedAs("_updateUI")]
        [Space(5)]

        [Header("UI")]
        [SerializeField] private UpdateUI updateUI;

        // Code

        private void Start() {
            Intermission();
        }

        private void Update() {
            if (timerActive) {
                if (timeLeft >= 0) {
                    timeLeft -= Time.deltaTime;
                    updateUI.UpdateTimer(timeLeft, startTimeAmount, gameState);
                } else {
                    timerActive = false;
                    timeLeft = 0f;
                    updateUI.UpdateTimer(timeLeft, startTimeAmount, gameState);
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
            startTimeAmount = timeLeft = _intermissionLength;
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
        }

        private void EndRound() {
            gameState = _validGameStates[4]; // Cleanup

            Intermission();
        }

    }
}