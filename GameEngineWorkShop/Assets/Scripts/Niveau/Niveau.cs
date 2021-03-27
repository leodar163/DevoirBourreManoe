using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Niveau : MonoBehaviour
{
    [SerializeField] private Cuby cuby;

    [SerializeField] private Section[] prefabSections = new Section[0];
    private List<Section> sections = new List<Section>();

    [SerializeField] private float distanceAffichage = 20;
    private float extremiteDroite = 0;
    private float extremiteGauche = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        VerifPositionCuby();        
    }

    private void VerifPositionCuby()
    {
        if(extremiteDroite - cuby.transform.position.x <= distanceAffichage)
        {
            AjouterSection();
        }
        if (cuby.transform.position.x - extremiteGauche >= distanceAffichage)
        {
            RetirerSection();
        }
    }

    public void RetirerSection()
    {
        Section sectionARetirer = sections[0];
        extremiteGauche += sectionARetirer.longueur;
        sections.Remove(sectionARetirer);
        Destroy(sectionARetirer.gameObject);
    }

    public void AjouterSection()
    {
        int alea = Random.Range(0, prefabSections.Length - 1);
        Section nvlleSection;
        if(Instantiate(prefabSections[alea].gameObject, transform).TryGetComponent(out nvlleSection))
        {
            nvlleSection.transform.position = new Vector3(extremiteDroite + nvlleSection.longueur / 2, 0, 0);
            extremiteDroite += nvlleSection.longueur;
            sections.Add(nvlleSection);
        }
    }

        
}
