using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class CameraMan : MonoBehaviour
{
    [SerializeField] private Camera cam;
    public Vector3 pointASuivre;
    [SerializeField] private float tmpsSuivit = 10;

    // Start is called before the first frame update
    void Start()
    {
        pointASuivre = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        SuivreCuby();
    }

    private void FixedUpdate()
    {

    }

    private void SuivreCuby()
    {
        Vector3 positionASuivre = pointASuivre;
        positionASuivre.y = 0;

        Vector2 velocity = Vector2.zero;
        Vector3 prochainePosition = Vector2.SmoothDamp(transform.position, positionASuivre, ref velocity, tmpsSuivit);
        prochainePosition.z = transform.position.z;

        transform.position = prochainePosition;
    }

    public void TremblerEcran(float force, float duree)
    {
        StartCoroutine(RoutineTremblement(force, duree));
    }

    private IEnumerator RoutineTremblement(float force, float duree)
    {
        float tempsDebut = Time.time;

        while (Time.time - tempsDebut < duree)
        {
            Vector3 impulsion = new Vector3(Random.Range(-force, force), Random.Range(-force, force));
            transform.position += impulsion;
            yield return new WaitForEndOfFrame();
        }
    }
}

