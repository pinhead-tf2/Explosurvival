using UnityEngine;

namespace Explosurvival.Bombs
{
    [CreateAssetMenu(fileName = "Bomb Object", menuName = "Bombs/Bomb Object", order = 0)]
    public class BombObject : ScriptableObject
    {
        public enum BombType
        {
            NoneType,
            Roller,
            Missile,
            Seeker
        }
        
        [Header("Info")] // Info used in bombonomicon, no impact on game
        public string m_Name;
        public BombType m_Type = BombType.NoneType;
        public string m_Tooltip; 
        [Header("Bomb")] // Handles how the bomb behaves, looks, and sounds
        public GameObject m_GameObj; // Assign behavior script on bomb
        public AudioClip m_TickSound; // Sounds during countdown ticks
        public AudioClip m_ExplosionSound; // Sounds on explosion
        public GameObject m_ExplosionEffect; // Script grabs this to spawn the explosion
        [Header("Stats")]
        public float m_Damage;
        public float m_Radius;
        public float m_FuseTime;
        public bool m_DestroyTerrain;
    }
}