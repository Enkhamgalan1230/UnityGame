using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EscPauseMenu : MonoBehaviour
{
    public GameObject pauseMenuReal;
    public bool isPaused;
    // Start is called before the first frame update
    public void Start()
    {
        pauseMenuReal.SetActive(false);
        
    }

    // Update is called once per frame
    public void Update()

    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
           
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }

        }
        
    }

    public void PauseGame()
    {
        pauseMenuReal.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }

    public void ResumeGame()
    {
        pauseMenuReal.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void NextLvl()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        pauseMenuReal.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }
}
