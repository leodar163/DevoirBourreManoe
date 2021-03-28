using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

    public class CameraMan : MonoBehaviour
    {
        [SerializeField] private Camera cam;
        [SerializeField] private Cuby cuby;
        [SerializeField] private float vitesse = 10;

        // Start is called before the first frame update
        void Start()
        {

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
            Vector3 positionASuivre = cuby.transform.position;
            positionASuivre.y = 0;

            Vector2 velocity = Vector2.zero;
            Vector3 prochainePosition = Vector2.SmoothDamp(transform.position, positionASuivre, ref velocity, 1 / vitesse * Time.timeScale);
            prochainePosition.z = transform.position.z;

            transform.position = prochainePosition;
        }
        
        public void TremblerEcran(float force, float duree)
        {
            transform.DOShakePosition(duree, force);
        }
    }

