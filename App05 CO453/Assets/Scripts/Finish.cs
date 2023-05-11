using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Finish : MonoBehaviour
{
    private AudioSource finishSound;

    private bool LevelCompleted = false;
    public GameObject pauseMenu;
    public  bool isPaused;
    [SerializeField] private Text Score;

    //public static int scorePoint = ItemCollector.bananas;



    private void Start()
    {
        finishSound = GetComponent<AudioSource>();
        pauseMenu.SetActive(false);
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player" && !LevelCompleted)
        {
            finishSound.Play();
            LevelCompleted = true;
           // Invoke("Pausegame", 2f);
           if (!isPaused)
            {
                Pausegame();
            }
            

        }
    }
    public void Pausegame()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
        Score.text = " Your testostrone lvl is at: " + ItemCollector.bananas + " Good Job! ";
        
        


        //Score.text = "Testostrone lvl : " + ItemCollector.bananas;
    }

    



    public void CompleteLevel()
    {
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        
        Time.timeScale = 1f;
        isPaused = false;
    }
    
}
