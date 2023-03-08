using Explosurvival.Bombs;
using Explosurvival.Bombs.Behaviors;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Explosurvival.Directors
{
    public class BombSpawnsDirector : MonoBehaviour
    {
        [SerializeField] private BombObject[] availableBombs;
        [SerializeField] private GameObject spawnCorner1;
        [SerializeField] private GameObject spawnCorner2; 
        private float _corner1Pos1;
        private float _corner1Pos2; 
        private float _corner2Pos1; 
        private float _corner2Pos2;

        private void Awake()
        {
            foreach (var aBomb in availableBombs)
            {
                aBomb.m_GameObj.GetComponent<BombBehaviour>().bomb = aBomb;
            }
        }

        private void Start()
        {
            var position1 = spawnCorner1.transform.position;
            var position2 = spawnCorner2.transform.position;
            _corner1Pos1 = position1.x;
            _corner1Pos2 = position1.z;
            _corner2Pos1 = position2.x;
            _corner2Pos2 = position2.z;
            Invoke(nameof(BombSpawns), 1f);
        }

        private void BombSpawns()
        {
            // Need to change instantiate based on bomb type
            availableBombs[0].m_GameObj.GetComponent<BombBehaviour>().bomb = availableBombs[0];
            var newBomb = Instantiate(availableBombs[0].m_GameObj, new Vector3(
                    Random.Range(_corner1Pos1, _corner2Pos1),
                    36.75f,
                    Random.Range(_corner1Pos2, _corner2Pos2)
                ), Quaternion.Euler(
                    new Vector3(
                        Random.Range(-360f, 360f),
                        Random.Range(-360f, 360f),
                        Random.Range(-360f, 360f)
                    )
                )
            );
            var newBombRb = newBomb.GetComponent<Rigidbody>();
            newBombRb.AddForce(Random.Range(-1f, 1f), -19.6f, Random.Range(-1f, 1f), ForceMode.VelocityChange);
            newBombRb.AddTorque(Random.Range(-3f, 3f), Random.Range(-3f, 3f), Random.Range(-3f, 3f), ForceMode.VelocityChange);
            Invoke(nameof(BombSpawns), Random.Range(8f, 12f)); // To be replaced with calculation
            // Factor in difficulty and available bombs
            // Maybe RoR2-like?
        }
    }
}