using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BombData", menuName = "Bombs/Bomb Base")]
public class BombData : ScriptableObject {
    [Header("Properties")]
    [SerializeField] string bombName;
    [SerializeField] GameObject bombPrefab ;
    [SerializeField] AudioSource beepSound;
    [SerializeField] AudioSource explosionSound;

    [Header("Stats")]
    [SerializeField] float fuseTime;
    [SerializeField] float damage = 10f;
    [SerializeField] float hitRadius;

    
}