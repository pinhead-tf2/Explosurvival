using System;
using Bombs;
using UnityEngine;

namespace Directors
{
    public class BombSpawnsDirector : MonoBehaviour
    {
        public GameObject bomb;

        private void Start()
        {
            Invoke("BombSpawns", 0f);
        }

        private void BombSpawns()
        {
            Instantiate(bomb, new Vector3(UnityEngine.Random.Range(-11.5f, 11.5f), 36.75f, UnityEngine.Random.Range(-11.5f, 11.5f)));
            Invoke("BombSpawns", UnityEngine.Random.Range(8f, 12f));
        }
    }
}