using UnityEngine.SceneManagement;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private bool isPaused=false;
    void Start()
    {
        isPaused = false;
        pauseMenu.SetActive(false);
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.P)) Pause();
    }

    public void Pause()
    {
        if (isPaused)
        {
            Time.timeScale = 1;
            pauseMenu.SetActive(false);
        }
        else
        {
            Time.timeScale = 0;
            pauseMenu.SetActive(true);
        }

        isPaused = !isPaused;
    }

    // Update is called once per frame
    public void Playgame()
    {
        SceneManager.LoadScene("Bait");
    }
    public void OnApplicationQuit()
    {
        Application.Quit();
    }
}
