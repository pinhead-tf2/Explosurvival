using System.Collections;
using UnityEngine;
using Explosurvival.UI;

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
        [Space(5)]

        [Header("Scripts")]
        [SerializeField] private UpdateUI updateUI;
        [SerializeField] private BombSpawnsDirector bombDirector;
        [SerializeField] private ItemSpawnDirector itemDirector;

        [Space(5)] [Header("Misc")] 
        [ReadOnlyAttribute, SerializeField] private GameObject[] players;
        [SerializeField] private GameObject spawnCorner1;
        [SerializeField] private GameObject spawnCorner2; 
        private float _corner1Pos1;
        private float _corner1Pos2; 
        private float _corner2Pos1; 
        private float _corner2Pos2;

        // Code

        private void Start()
        {
            var position1 = spawnCorner1.transform.position;
            var position2 = spawnCorner2.transform.position;
            _corner1Pos1 = position1.x;
            _corner1Pos2 = position1.z;
            _corner2Pos1 = position2.x;
            _corner2Pos2 = position2.z;
            players = GameObject.FindGameObjectsWithTag("Player");

            bombDirector = bombDirector.GetComponent<BombSpawnsDirector>();
            itemDirector = itemDirector.GetComponent<ItemSpawnDirector>();
            itemDirector.enabled = bombDirector.enabled = false;
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
            timerActive = false;
            startTimeAmount = timeLeft = _roundLength;
            // load up playspace
            foreach (var player in players)
            {
                var characterController = player.GetComponent<CharacterController>();
                characterController.enabled = false;
                player.transform.position = new Vector3(
                    Random.Range(_corner1Pos1, _corner2Pos1),
                    30.75f,
                    Random.Range(_corner1Pos2, _corner2Pos2)
                );
                characterController.enabled = true;
                print("teleported");
            }
            // put up transition ui
            updateUI.SwapUISet(true);
            StartCoroutine(Countdown());
        }

        private void GameLoop() {
            gameState = _validGameStates[3]; // Playing
            timerActive = true;
            itemDirector.enabled = bombDirector.enabled = true;
            // Make bomb and item directors active
        }

        private void EndRound() {
            gameState = _validGameStates[4]; // Cleanup
            updateUI.SwapUISet(false);
            itemDirector.enabled = bombDirector.enabled = false;
            // ReSharper disable once Unity.PerformanceCriticalCodeInvocation | Disabled because required CancelInvoke
            bombDirector.CancelInvoke("BombSpawns");
            Intermission();
        }

        private IEnumerator Countdown()
        {
            // call countdown ui
            yield return new WaitForSeconds(3);
            timerActive = true;
            GameLoop();
        }
    }
}
