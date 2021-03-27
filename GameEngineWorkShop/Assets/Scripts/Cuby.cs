using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Cuby : MonoBehaviour
{
    [SerializeField] private Viseur viseur;
    [SerializeField] private float tmpsDash = 1;
    private bool peutDasher = true;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        AffecterControles();
    }

    private void AffecterControles()
    {
        if (Input.GetMouseButtonUp(0))
        {
            Dash();

        }
    }

    private void Dash()
    {
        if(peutDasher)
        {
            RaycastHit rayCast;
            if (Physics.Raycast(transform.position, viseur.transform.up, out rayCast, Mathf.Infinity, LayerMask.GetMask("Surface")))
            {
                peutDasher = false;

                viseur.gameObject.SetActive(false);
                Time.timeScale = 0.01f;
                transform.up = rayCast.normal;
                transform.DOMove(rayCast.point, tmpsDash * Time.timeScale).OnComplete(() => {

                    Time.timeScale = 1;
                    viseur.gameObject.SetActive(true);
                    peutDasher = true;

                });


            }
        }
    }

    private void OnDrawGizmos()
    {
        RaycastHit ray;
        Gizmos.color = Color.red;
        if (Physics.Raycast(transform.position, viseur.transform.up, out ray, Mathf.Infinity, LayerMask.GetMask("Surface")))
        {
            Gizmos.DrawLine(transform.position, ray.point);
        }
        else
        {
            Gizmos.DrawLine(transform.position, viseur.transform.up * 10000);
        }
    }
}
