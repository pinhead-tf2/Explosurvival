using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerBomb : MonoBehaviour
{
    [Header("Bomb Stats")]
    [SerializeField] float fuseTime;
    [SerializeField] float damage = 10f;
    [SerializeField] float hitRadius;
    [SerializeField] AudioSource beepSound;
    [SerializeField] AudioSource explosionSound;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Explode() {

    }

}
