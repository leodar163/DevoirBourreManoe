using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

        }

        private void FixedUpdate()
        {
            SuivreCuby();
        }
        private void SuivreCuby()
        {
            Vector3 positionSouris = cam.ScreenToWorldPoint(Input.mousePosition);

            Vector3 positionASuivre = cuby.transform.position;

            Vector3 prochainePosition = Vector2.Lerp(transform.position, positionASuivre, 1 * Time.deltaTime * vitesse);
            prochainePosition.z = transform.position.z;

            transform.position = prochainePosition;
        }

    }

