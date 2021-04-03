using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MenuFin : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textReccord;

    // Start is called before the first frame update
    void Start()
    {
        VerifReccord();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void VerifReccord()
    {
        int dernierScore = PlayerPrefs.GetInt("Monnaie");

        if (dernierScore != 0 && dernierScore != default && dernierScore > PlayerPrefs.GetInt("Record"))
        {
            PlayerPrefs.SetInt("Record", dernierScore);

            AfficherReccord(dernierScore);
        }
    }

    private void AfficherReccord(int nvReccord)
    {
        textReccord.gameObject.SetActive(true);
        textReccord.text = nvReccord + "\nNOUVEAU RECORD !";
    }
}
