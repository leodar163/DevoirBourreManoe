using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MurDeFlammes : MonoBehaviour
{
    [SerializeField] private float vitesse = 3.0f;
    [SerializeField] private int hauteur;
    [SerializeField] private GameObject player;
    [SerializeField] private float coefficientVitesse;
    private bool arreteDeBouger = false;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnValidate()
    {
        transform.localScale = new Vector3(transform.localScale.x, hauteur, transform.localScale.z);
    }

    private void Move()
    {
        float dist = Vector3.Distance(player.transform.position, gameObject.transform.position);
        transform.Translate(Vector3.right * (vitesse + coefficientVitesse * (dist-4.6f)) * Time.fixedDeltaTime);

    }


    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if (!arreteDeBouger)
        {
            Move();
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Cuby player;
        if (other.transform.parent.parent.TryGetComponent(out player))
        {
            player.gameOver.Invoke();
        }
        
        
    }
}
