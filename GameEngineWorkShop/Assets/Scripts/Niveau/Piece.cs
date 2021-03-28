using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Piece : MonoBehaviour
{
    public UnityEvent quandDetruite = new UnityEvent();

    private void Start()
    {
        quandDetruite.AddListener(Detruire);    
    }

    private void Detruire()
    {
        Destroy(gameObject);
    }
}
