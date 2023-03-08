using System;
using System.Collections;
using System.Collections.Generic;
using Explosurvival.Bombs;
using Explosurvival.Bombs.Behaviors;
using UnityEngine;

public class ReplaceOnSpawn : MonoBehaviour
{
    public BombObject toSpawn;

    private void Start()
    {
        toSpawn.m_GameObj.GetComponent<BombBehaviour>().bomb = toSpawn;
        StartCoroutine(Replacer());
    }

    private IEnumerator Replacer()
    {
        yield return new WaitForSeconds(5);
        Instantiate(toSpawn.m_GameObj, transform);
    }
}
