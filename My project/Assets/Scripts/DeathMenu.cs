using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathMenu : MonoBehaviour
{
    
    [SerializeField] private GameObject deathMenu;

    public void TheEnd()
    {
        Time.timeScale = 0;
        deathMenu.SetActive(true);
    }
    public void Tomain()
    {
        SceneManager.LoadScene("Bait");
    }
    public void OnApplicationQuit()
    {
        Application.Quit();
    }
}
