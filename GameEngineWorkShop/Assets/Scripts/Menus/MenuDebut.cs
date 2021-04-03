using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class MenuDebut : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI meilleurScore;

    private void Awake()
    {
        AfficherMeilleurScore();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AfficherMeilleurScore()
    {
        int reccord = PlayerPrefs.GetInt("Record");
        meilleurScore.text = "Record : \n" + reccord;
    }

    public void Jouer()
    {
        SceneManager.LoadSceneAsync("Niveau1");
    }

    public void Quitter()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
