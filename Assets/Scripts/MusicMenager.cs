using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicMenager : MonoBehaviour
{
    public GameObject[] songs = new GameObject[3];
    public GameObject activeSong;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Keypad1))
        {
            FindObjectOfType<PlayerInput>().isPlaying = false;
            foreach (var vSong in songs)
            {
                vSong.SetActive(false);
            }
            songs[0].SetActive(true);
            FindObjectOfType<spawnertwo>().freq = songs[0].GetComponent<music>().freq;
            FindObjectOfType<spawnertwo>().spawnTreshold = songs[0].GetComponent<music>().tresshold;
            activeSong = songs[0];

        }
        if (Input.GetKey(KeyCode.Keypad2))
        {
            FindObjectOfType<PlayerInput>().isPlaying = false;
            foreach (var vSong in songs)
            {
                vSong.SetActive(false);
            }
            songs[1].SetActive(true);
            FindObjectOfType<spawnertwo>().freq = songs[1].GetComponent<music>().freq;
            FindObjectOfType<spawnertwo>().spawnTreshold = songs[1].GetComponent<music>().tresshold;
            activeSong = songs[1];
        }
        if (Input.GetKey(KeyCode.Keypad3))
        {
            FindObjectOfType<PlayerInput>().isPlaying = false;
            foreach (var vSong in songs)
            {
                vSong.SetActive(false);
            }
            songs[2].SetActive(true);
            FindObjectOfType<spawnertwo>().freq = songs[2].GetComponent<music>().freq;
            FindObjectOfType<spawnertwo>().spawnTreshold = songs[2].GetComponent<music>().tresshold;
            activeSong = songs[2];
        }
        if (Input.GetKey(KeyCode.Keypad4))
        {
            FindObjectOfType<PlayerInput>().isPlaying = false;
            foreach (var vSong in songs)
            {
                vSong.SetActive(false);
            }
            songs[3].SetActive(true);
            FindObjectOfType<spawnertwo>().freq = songs[3].GetComponent<music>().freq;
            FindObjectOfType<spawnertwo>().spawnTreshold = songs[3].GetComponent<music>().tresshold;
            activeSong = songs[3];
        }
    }
}
