using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Viseur : MonoBehaviour
{
    [SerializeField] private float angleMax = 60;
    [SerializeField] private float vitesseRotation = 3;

    private void OnEnable()
    {
        InitVisee();
    }

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
        StopAllCoroutines();
        transform.localRotation = Quaternion.Euler(0,0,angleMax);
        StartCoroutine(Viser());
    }


    private IEnumerator Viser()
    {
        float angleActuel = Mathf.Round(transform.localEulerAngles.z);
        float angleCilble = angleActuel == angleMax ? 360 - angleMax : angleActuel == 360 - angleMax ? angleMax : angleMax;
        float angleDepart = angleActuel;

        float tmpsLerp = 0;

        while (angleActuel != angleCilble)
        {
            transform.localRotation = Quaternion.Lerp(Quaternion.AngleAxis(angleDepart, Vector3.forward), Quaternion.AngleAxis(angleCilble, Vector3.forward), tmpsLerp);
            angleActuel = Mathf.Round(transform.localEulerAngles.z);
            yield return new WaitForEndOfFrame();
            tmpsLerp += Time.deltaTime * vitesseRotation;
        }

        StartCoroutine(Viser());
    }
}
