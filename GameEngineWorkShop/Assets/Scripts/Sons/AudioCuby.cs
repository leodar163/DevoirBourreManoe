using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioCuby : GestionnaireSon
{
    [SerializeField] private AudioClip[] sonsDash;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LancerSonDash()
    {
        LancerSon(sonsDash);
    }
}
