using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Viseur : MonoBehaviour
{
    [SerializeField] private float angleDepart = 0;
    [SerializeField] private float angleMax = 60;
    [SerializeField] private float vitesseRotation = 3;

    // Start is called before the first frame update
    void Start()
    {
        InitVisee();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void InitVisee()
    {
        transform.Rotate(Vector3.forward, angleDepart);
        transform.DOLocalRotate(Vector3.forward * angleMax, vitesseRotation / 2).OnComplete(Viser);
    }

    private void Viser()
    {
        float angleActuel = Mathf.Round(transform.localEulerAngles.z);
        if (angleActuel == angleMax)
        {
            transform.DOLocalRotate(Vector3.forward * -angleMax, vitesseRotation).OnComplete(Viser);
        }
        else if (angleActuel == 360 - angleMax)
        {
            transform.DOLocalRotate(Vector3.forward * angleMax, vitesseRotation).OnComplete(Viser);
        }
    }
}
