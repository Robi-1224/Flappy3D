using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    [SerializeField] GameObject creditsPanel;
    [SerializeField] GameObject pausedPanel;
    private PlayerControl playerControl;
   
    public bool isPaused = false;

    private void Start()
    {
        playerControl = FindAnyObjectByType<PlayerControl>();
      
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

    private void pauseGame()
    {
       


            if (Input.GetKey(KeyCode.Escape))
            {
                isPaused = true;
                pausedPanel.SetActive(true);

                playerControl.gameObject.GetComponent<Rigidbody>().useGravity = false;
                playerControl.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
                playerControl.enabled = false;
                
          
            }

            if (!isPaused)
            {
               if(!playerControl.gameOver) { 
                    
                playerControl.enabled = true;

                playerControl.gameObject.GetComponent<Rigidbody>().useGravity = true;
            }
               
            }
    }
}
