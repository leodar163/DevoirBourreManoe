using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Section : MonoBehaviour
{
    public float longueur = 4;
    [SerializeField] private GameObject sol;
    [SerializeField] private GameObject plafond;

    private void OnValidate()
    {
        sol.transform.localScale = new Vector3(longueur, sol.transform.localScale.y, sol.transform.localScale.z);
        plafond.transform.localScale = new Vector3(longueur, plafond.transform.localScale.y, plafond.transform.localScale.z);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
