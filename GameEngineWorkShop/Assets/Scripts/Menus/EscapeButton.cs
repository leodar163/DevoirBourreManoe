using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class EscapeButton : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI menu;
    [SerializeField] private TextMeshProUGUI reprendre;
    [SerializeField] private GameObject panel;
    private bool echap = false;

    // Start is called before the first frame update
    void Start()
    {
        menu.gameObject.SetActive(false);
        reprendre.gameObject.SetActive(false);
        panel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Time.timeScale = 0;
            echap = true;
            menu.gameObject.SetActive(true);
            reprendre.gameObject.SetActive(true);
            panel.SetActive(true);
        }
        
    }

    public void Unpause()
    {
        echap = false;
        menu.gameObject.SetActive(false);
        reprendre.gameObject.SetActive(false);
        panel.SetActive(false);
    }


    public void Menu()
    {
        SceneManager.LoadSceneAsync("MenuDebut");
    }


    public bool estActive()
    {
        return echap;
    }
}
