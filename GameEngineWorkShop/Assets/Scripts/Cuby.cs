using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using DG.Tweening;
using TMPro;

public class Cuby : MonoBehaviour
{
    [SerializeField] private CameraMan cameraMan;
    [SerializeField] private GameObject visuMesh;
    [SerializeField] private Viseur viseur;
    [SerializeField] private float tmpsDash = 1;
    [SerializeField] PorteMonnaie porteMonnaie;
    private bool peutDasher = true;
    public UnityEvent gameOver = new UnityEvent();

    // Start is called before the first frame update
    void Start()
    {
        gameOver.AddListener(GameOver);
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
            RaycastHit[] hits = Physics.RaycastAll(transform.position, viseur.transform.up, Mathf.Infinity, LayerMask.GetMask("Piece", "Surface"));

            for (int i = 0; i < hits.Length; i++)
            {
                if (hits[i].collider.gameObject.layer == 6)
                {
                    break;
                }
                Piece piece;
                if (hits[i].collider.TryGetComponent(out piece))
                {
                    porteMonnaie.quandPieceAjoutee.Invoke();
                    piece.quandDetruite.Invoke();
                }

            }


            RaycastHit rayCast;
            if (Physics.Raycast(transform.position, viseur.transform.up, out rayCast, Mathf.Infinity, LayerMask.GetMask("Surface")))
            {
                peutDasher = false;

                viseur.gameObject.SetActive(false);
                Time.timeScale = 0.01f;
                visuMesh.transform.DOScale(0.1f, 0.2f * Time.timeScale);
                transform.up = rayCast.normal;
                transform.DOMove(rayCast.point, tmpsDash * Time.timeScale).OnComplete(() => {

                    Time.timeScale = 1;
                    if (cameraMan) cameraMan.TremblerEcran(0.5f, 0.3f);
                    visuMesh.transform.DOScale(1f, 0.1f * Time.timeScale).OnComplete(() => { 
                    
                        visuMesh.transform.DOPunchScale(-transform.up * 0.4f, 0.3f);
                    });

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

    private void GameOver()
    {
        Time.timeScale = 0;
    }

    
}
