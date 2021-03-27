using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PorteMonnaie : MonoBehaviour
{

    private int coins = 0;

    public void Incrementer()
    {
        coins += 1;
        Debug.Log(coins);
    }
}
