using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using DG.Tweening;
using TMPro;
using UnityEngine.SceneManagement;

public class Cuby : MonoBehaviour
{
    [SerializeField] private ParticleSystem psMort;
    [SerializeField] private CameraMan cameraMan;
    [SerializeField] private GameObject visuMesh;
    [SerializeField] private Viseur viseur;
    [SerializeField] private float tmpsDash = 1;
    [SerializeField] PorteMonnaie porteMonnaie;

    public UnityEvent quandDash = new UnityEvent();
    public UnityEvent quandAtterit = new UnityEvent();

    private bool peutDasher = true;
    public UnityEvent gameOver = new UnityEvent();

    // Start is called before the first frame update
    void Start()
    {
        gameOver.AddListener(() => {
            StartCoroutine(GameOver());
            });
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
                quandDash.Invoke();

                RaycastHit[] hits = Physics.RaycastAll(transform.position, viseur.transform.up, Mathf.Infinity, LayerMask.GetMask("Piece"));
                for (int i = 0; i < hits.Length; i++)
                {
                    if (hits[i].distance > rayCast.distance)
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

                peutDasher = false;

                viseur.gameObject.SetActive(false);

                visuMesh.transform.DOScale(0.1f, 0.2f);
                transform.up = rayCast.normal;

                cameraMan.pointASuivre = rayCast.point;

                transform.DOMove(rayCast.point, tmpsDash).OnComplete(() => {

                    quandAtterit.Invoke();

                    cameraMan.TremblerEcran(0.05f, 0.2f);

                    visuMesh.transform.DOScale(1f, 0.1f).OnComplete(() => { 
                    
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

    private IEnumerator GameOver()
    {
        peutDasher = false;
        psMort.Play();
        cameraMan.TremblerEcran(1, 0.5f);
        visuMesh.gameObject.SetActive(false);
        viseur.gameObject.SetActive(false);

        PlayerPrefs.SetInt("Monnaie", porteMonnaie.coins);

        while(psMort.isPlaying)
        {
            peutDasher = false;
            yield return new WaitForEndOfFrame();
        }
        
        
        SceneManager.LoadSceneAsync("MenuFin");
    }

    
}
