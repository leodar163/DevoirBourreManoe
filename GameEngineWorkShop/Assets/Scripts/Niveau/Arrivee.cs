using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Arrivee : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI text; 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.name);
        Cuby player;
        if (other.transform.parent.TryGetComponent(out player))
        {
            text.gameObject.SetActive(true);
            Destroy(player.gameObject);
            Time.timeScale = 0;
        }
    }

}
