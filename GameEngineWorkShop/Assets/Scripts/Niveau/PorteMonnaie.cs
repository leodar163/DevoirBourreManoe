using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PorteMonnaie : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI text;
    private int coins = 0;


    public void Incrementer()
    {
        coins += 1;
        text.SetText(coins.ToString());
        Debug.Log(coins);
    }
}
