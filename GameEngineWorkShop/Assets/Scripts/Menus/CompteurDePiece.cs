using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class CompteurDePiece : MonoBehaviour
{
    public int coins = 0;
    [SerializeField] public TextMeshProUGUI text;

    private void Start()
    {
    }

    public void Incrementer()
    {
        coins++;
        text.text = "SCORE {"+ coins +"}";
    }
}
