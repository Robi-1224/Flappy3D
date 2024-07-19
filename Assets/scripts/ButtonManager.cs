using Microsoft.Unity.VisualStudio.Editor;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

[RequireComponent(typeof(SaveScoreScript))]

public class ButtonManager : MonoBehaviour
{
    [SerializeField] GameObject creditsPanel;
    [SerializeField] GameObject pausedPanel;
    [SerializeField] GameObject highscorePanel;
    [SerializeField] GameObject background;
    [SerializeField] TextMeshProUGUI highscoreText;

    private PlayerControl playerControl;
    private Score score;
    private SaveScoreScript saveScore;
   
    public bool isPaused = false;

    private void Start()
    {
        playerControl = FindAnyObjectByType<PlayerControl>();
       score = FindAnyObjectByType<Score>();
        saveScore = GetComponent<SaveScoreScript>();
      
    }
    private void Update()
    {
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("MainScene"))
        {
            pauseGame();
        }
    }
    public void GameStart()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void GameQuit()
    {
        Application.Quit();
    }

    public void Credits()
    {
        creditsPanel.SetActive(true);
    }

    public void CreditsQuit()
    {
        creditsPanel.SetActive(false);
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void Unpause()
    {
        pausedPanel.SetActive(false);
        isPaused = false;

    }

    public void Retry()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void HighScorePanel()
    {
        highscorePanel.SetActive(true);
        highscoreText.text = score.highScore + " " + "Points!";
    }

    public void HighScoreQuit()
    {
        highscorePanel.SetActive(false);
    }

    public void HighScoreReset()
    {
        score.highScore = 0;
        
        saveScore.SaveData();
        HighScorePanel();
    }

    private void pauseGame()
    {
       


            if (Input.GetKey(KeyCode.Escape))
            {
                isPaused = true;
                background.GetComponent<Movement>().enabled= false;
                pausedPanel.SetActive(true);

                playerControl.gameObject.GetComponent<Rigidbody>().useGravity = false;
                playerControl.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
                playerControl.enabled = false;
                
          
            }

            if (!isPaused)
            {

              background.GetComponent<Movement>().enabled= true;

               if(!playerControl.gameOver) { 
                    
                playerControl.enabled = true;

                playerControl.gameObject.GetComponent<Rigidbody>().useGravity = true;
            }
               
            }
    }
}
