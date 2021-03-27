using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Viseur : MonoBehaviour
{
    [SerializeField] private float angleDepart = 0;
    [SerializeField] private float angleMax = 45;
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
        print(string.Format("{0} == {1} : {2}", transform.eulerAngles.z, angleMax, transform.eulerAngles.z.Equals(angleMax)));
        if (transform.localEulerAngles.z == angleMax)
        {
            print("vers la droite");
            transform.DOLocalRotate(Vector3.forward * -angleMax, vitesseRotation).OnComplete(Viser);
        }
        else if (transform.localEulerAngles.z == 360 - angleMax)
        {
            print("vers la gauche");
            transform.DOLocalRotate(Vector3.forward * angleMax, vitesseRotation).OnComplete(Viser);
        }
    }
}
