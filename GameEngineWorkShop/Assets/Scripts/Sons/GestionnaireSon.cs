using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GestionnaireSon : MonoBehaviour
{
    [SerializeField] private AudioSource audioS;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    protected void LancerSon(AudioClip audio)
    {
        audioS.clip = audio;
        audioS.Play();
    }

    protected void LancerSon(AudioClip[] audios)
    {
        int alea = Random.Range(0, audios.Length - 1);
        LancerSon(audios[alea]);
    }
}
