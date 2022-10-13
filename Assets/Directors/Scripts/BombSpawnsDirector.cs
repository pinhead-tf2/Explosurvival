using System;
using Bombs;
using UnityEngine;
using Random = System.Random;

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
            // Need to change instantiate based on bomb type
            GameObject newBomb = Instantiate(bomb, new Vector3(
                    UnityEngine.Random.Range(-11.5f, 11.5f), 
                    36.75f, 
                    UnityEngine.Random.Range(-11.5f, 11.5f)
                ), Quaternion.Euler(
                    new Vector3(
                        UnityEngine.Random.Range(-360f, 360f), 
                        UnityEngine.Random.Range(-360f, 360f), 
                        UnityEngine.Random.Range(-360f, 360f)
                    )
                )
            );
            newBomb.GetComponent<Rigidbody>().AddForce(0, -19.6f, 0, ForceMode.Impulse);
            Invoke("BombSpawns", UnityEngine.Random.Range(8f, 12f));
        }
    }
}