using UnityEngine;

namespace Explosurvival.Bombs
{
    [CreateAssetMenu(fileName = "Bomb Object", menuName = "Bombs/Bomb Object", order = 0)]
    public class BombObject : ScriptableObject
    {
        [Header("Info")]    
        [SerializeField] string m_Name;
        [SerializeField] string m_Type;
        [SerializeField] string m_Tooltip;
        [Header("Core")]
        [SerializeField] GameObject m_Model;
        [SerializeField] BombBehavior m_BehaviorScript;
        [Header("Stats")]
        [SerializeField] float m_Time;
        [SerializeField] float m_Damage;
        [SerializeField] bool m_GravityAffected;
    }
}