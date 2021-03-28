using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class GestionnaireCouleurNiveau : MonoBehaviour
{
    [SerializeField] private Material MatSruface;
    [SerializeField] private float vitesseRoulement;
    private float tmpsLerp = 0;
    private float hueActuel = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RoulementCouleur();
    }

    private void RoulementCouleur()
    {
        if (hueActuel >= 1) tmpsLerp = 0;

        tmpsLerp += Time.deltaTime * vitesseRoulement;

        hueActuel = Mathf.Lerp(0, 1, tmpsLerp);
        MatSruface.SetColor("_EmissionColor", Color.HSVToRGB(hueActuel, 1, 0.7f));
    }
}
