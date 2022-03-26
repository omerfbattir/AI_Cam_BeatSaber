using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class music : MonoBehaviour
{
    public int freq;
    public float tresshold;

    private void Awake()
    {
        FindObjectOfType<spawnertwo>().freq = freq;
        FindObjectOfType<spawnertwo>().spawnTreshold = tresshold;
    }

    private void Update()
    {
        
    }
}
