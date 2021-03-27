using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Cuby : MonoBehaviour
{
    [SerializeField] private Viseur viseur;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        AffecterControles();
    }

    private void AffecterControles()
    {
        if (Input.GetMouseButtonUp(0))
        {
            viseur.gameObject.SetActive(false);
        }
    }
}
