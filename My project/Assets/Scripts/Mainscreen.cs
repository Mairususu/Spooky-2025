using UnityEngine;
using UnityEngine.SceneManagement;

public class Mainscreen : MonoBehaviour
{
    [SerializeField] private GameObject mainPanel;
    [SerializeField] private GameObject optionsPanel;
    [SerializeField] private GameObject creditsPanel;
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
        mainPanel.SetActive(true);
        optionsPanel.SetActive(false);
        creditsPanel.SetActive(false);
    }

    public void ToOptionsPanel()
    {
        mainPanel.SetActive(false);
        optionsPanel.SetActive(true);
        creditsPanel.SetActive(false);
    }

    public void ToCreditsPanel()
    {
        mainPanel.SetActive(false);
        optionsPanel.SetActive(false);
        creditsPanel.SetActive(true);
        
    }

    #endregion
    public void OnApplicationQuit()
    {
        Application.Quit();
    }
}
