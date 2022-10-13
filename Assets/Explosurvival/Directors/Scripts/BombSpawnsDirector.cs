using UnityEngine;
using Random = UnityEngine.Random;

namespace Explosurvival.Directors
{
    public class BombSpawnsDirector : MonoBehaviour
    {
        public GameObject bomb;
        [SerializeField] private GameObject spawnCorner1;
        [SerializeField] private GameObject spawnCorner2;

        private void Start()
        {
            var position1 = spawnCorner1.transform.position;
            var position2 = spawnCorner2.transform.position;
            float corner1Pos1 = position1.x;
            float corner1Pos2 = position1.z;
            float corner2Pos1 = position2.x;
            float corner2Pos2 = position2.z;
            Invoke("BombSpawns", 1f);
        }

        private void BombSpawns()
        {
            // Need to change instantiate based on bomb type
            var newBomb = Instantiate(bomb, new Vector3(
                    Random.Range(-11.5f, 11.5f), 
                    36.75f, 
                    Random.Range(-11.5f, 11.5f)
                ), Quaternion.Euler(
                    new Vector3(
                        Random.Range(-360f, 360f), 
                        Random.Range(-360f, 360f), 
                        Random.Range(-360f, 360f)
                    )
                )
            );
            var newBombRb = newBomb.GetComponent<Rigidbody>();
            newBombRb.AddForce(Random.Range(-1, 1), -19.6f, Random.Range(-1, 1), ForceMode.VelocityChange);
            newBombRb.AddTorque(Random.Range(-2, 2), Random.Range(-2, 2), Random.Range(-2, 2), ForceMode.VelocityChange);
            Invoke("BombSpawns", Random.Range(8f, 12f));
        }
    }
}