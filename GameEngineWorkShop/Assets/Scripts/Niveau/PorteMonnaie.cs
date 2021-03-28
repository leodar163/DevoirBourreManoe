using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class PorteMonnaie : MonoBehaviour
{
    public int coins = 0;
    public UnityEvent quandPieceAjoutee = new UnityEvent();

    private void Start()
    {
        quandPieceAjoutee.AddListener(Incrementer);
    }

    private void Incrementer()
    {
        coins ++;
    }
}
