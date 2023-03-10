using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScratchFile : MonoBehaviour
{
    private int[] _collection = new int[10];
    void Start()
    {
        _collection[0] = 1;
        _collection[1] = 2;
        _collection[2] = 3;
        _collection[3] = 4;
        _collection[4] = 5;
        
        foreach (var variable in _collection)
        {
            print("" + _collection[variable]);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
