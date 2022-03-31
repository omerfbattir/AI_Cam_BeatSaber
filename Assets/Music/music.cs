using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class music : MonoBehaviour
{
    public int freq;
    public float tresshold;
    public AudioSource[] audioSource = new AudioSource[1];
    public float delayTime;
    private void Awake()
    {
        FindObjectOfType<spawnertwo>().freq = freq;
        FindObjectOfType<spawnertwo>().spawnTreshold = tresshold;
    }
}
