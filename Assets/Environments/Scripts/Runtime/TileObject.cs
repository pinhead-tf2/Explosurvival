using UnityEngine;

namespace Environments
{
    [CreateAssetMenu(fileName = "Tile Object", menuName = "Environments/Tile Object", order = 0)]
    public class TileObject : ScriptableObject
    {
        [SerializeField] int m_Health;
        [SerializeField] Color32 m_Color;
        [SerializeField] Material m_Material;
    }
}