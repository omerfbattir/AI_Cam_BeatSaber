using System;
using UnityEngine;
using TMPro;

public class PlayerStats : MonoBehaviour
{
    public int point = 0;
    public TMP_Text _text;

    private void Update()
    {
        _text.text = "Score: " + point.ToString();
    }
}
 