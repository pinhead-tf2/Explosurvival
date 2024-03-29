﻿using System;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;
using TMPro;

namespace Explosurvival.UI
{
    public class UpdateUI : MonoBehaviour
    {
        [Header("UI Set")]
        [SerializeField] private GameObject lobbyUISet;
        [SerializeField] private GameObject gameUISet;
        [Space(5)]
        [Header("Lobby")]
        [SerializeField] private Image clockArmLobby;
        [SerializeField] private TextMeshProUGUI timerTextLobby;
        [Space(5)]
        [Header("Game")]
        [SerializeField] private Image clockArmGame;
        [SerializeField] private TextMeshProUGUI timerTextGame;

        private void Start()
        {
            lobbyUISet.SetActive(true);
            gameUISet.SetActive(false);
        }

        public void UpdateTimer(float timeLeft, float startAmount, string currentState) 
        {
            var tss = TimeSpan.FromSeconds(timeLeft);
            var newText = $"{tss.Minutes:0}:{tss.Seconds:00}"; // woah, very cool thank you intellij
            var newRot = new Vector3(0, 0, timeLeft / startAmount * 360);
            if (currentState == "Intermission")
            {
                timerTextLobby.text = newText;
                clockArmLobby.transform.eulerAngles = newRot;
            }
            else if (currentState == "Playing")
            {
                timerTextGame.text = newText;
                clockArmGame.transform.eulerAngles = newRot;
            }
        }

        public void SwapUISet(bool value) // true to use game, false to use lobby
        {
            // Put up transition to hide the swap
            lobbyUISet.SetActive(!value);
            gameUISet.SetActive(value);
        }
    }
}