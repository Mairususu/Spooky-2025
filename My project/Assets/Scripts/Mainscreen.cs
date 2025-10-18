using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Mainscreen : MonoBehaviour
{
    [SerializeField] private GameObject MainPanel;
    [SerializeField] private GameObject OptionsPanel;
    [SerializeField] private GameObject CreditsPanel;
    void Start()
    {
        ToMainPanel();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Playgame()
    {
        SceneManager.LoadScene(1);
    }
    #region ChangePanel

    public void ToMainPanel()
    {
        MainPanel.SetActive(true);
        OptionsPanel.SetActive(false);
        CreditsPanel.SetActive(false);
    }

    public void ToOptionsPanel()
    {
        MainPanel.SetActive(false);
        OptionsPanel.SetActive(true);
        CreditsPanel.SetActive(false);
    }

    public void ToCreditsPanel()
    {
        MainPanel.SetActive(false);
        OptionsPanel.SetActive(false);
        CreditsPanel.SetActive(true);
    }

    #endregion
    private void OnApplicationQuit()
    {
        Application.Quit();
    }
}
