using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Piece : MonoBehaviour
{
    [SerializeField] private ParticleSystem ps;
    [SerializeField] private GameObject mesh;
    [SerializeField] private float vitesseRotation = 1;
    public UnityEvent quandDetruite = new UnityEvent();

    private void Start()
    {
        quandDetruite.AddListener(() => {
            StartCoroutine(Detruire());
            });    
    }

    private void Update()
    {
        mesh.transform.localEulerAngles = mesh.transform.localEulerAngles + Vector3.up * (vitesseRotation * Time.deltaTime);
    }

    private IEnumerator Detruire()
    {
        ps.Play();
        gameObject.layer = 0; //pour éviter que le joueur puisse touché la piece pendant son animation de destruction
        mesh.SetActive(false);
        while(ps.isPlaying)
        {
            yield return new WaitForEndOfFrame();
        }
        Destroy(gameObject);
    }
}
