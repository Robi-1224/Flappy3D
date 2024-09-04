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
    [SerializeField] GameObject skinPanel;
    [SerializeField] GameObject equipButton;
    [SerializeField] GameObject purchaseButton;

    [SerializeField] TextMeshProUGUI highscoreText;
    [SerializeField] TextMeshProUGUI inputNameText;
    [SerializeField] TextMeshProUGUI championNameText;
    [SerializeField] TextMeshProUGUI ownedText;

    private PlayerControl playerControl;
    private Score score;
    private SaveScoreScript saveScore;
    private UnlockedCheck check;
    private SkinManager skinManager;
    private UnlockedCheck unlockedCheck;
    public GameObject[] objects;
    public bool isPaused = false;
    public bool skinUnlocked = false;
    private void Start()
    {
        playerControl = FindAnyObjectByType<PlayerControl>();
        score = FindAnyObjectByType<Score>();
        saveScore = GetComponent<SaveScoreScript>();
        check = FindAnyObjectByType<UnlockedCheck>();
        skinManager = FindAnyObjectByType<SkinManager>();
        unlockedCheck = FindAnyObjectByType<UnlockedCheck>() ;

        
    }
    private void Update()
    {
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("MainScene") || SceneManager.GetActiveScene() == SceneManager.GetSceneByName("ReloadScene"))
        {
            pauseGame();
        }
        else
        {
            skinManager.currentSkinOwned = skinManager.skins[skinManager.skinsIndex].gameObject.GetComponent<UnlockedCheck>().unlcocked;
            if (!skinManager.skins[skinManager.skinsIndex].gameObject.GetComponent<UnlockedCheck>().unlcocked)
            {
                purchaseButton.SetActive(true);
                equipButton.SetActive(false);
                skinManager.amountText.enabled = true;
                ownedText.enabled = false;
            }
            else
            {
                equipButton.SetActive(true);
                purchaseButton.SetActive(false);
                ownedText.enabled = true;
                skinManager.amountText.enabled = false;
            }
        }

        
       



    }

    public void SkinPanelActive()
    {
        skinPanel.SetActive(true);
    }

    public void SkinPanelDeacive()
    {
            skinPanel.SetActive(false);
        
    }
    public void GameStart()
    {
        if (skinManager.currentSkinOwned)
        {


            SceneManager.LoadScene("MainScene");
            saveScore.SaveData();
        }
        else
        {
            Debug.Log("You need to equip a bird!");
        }
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
        if (saveScore.InputName == true || score.highScoreObject.gameObject.active == false)
        {
            SceneManager.LoadScene("MainMenu");
        }
        else
        {
            inputNameText.enabled = true;
        }
    }

    public void Unpause()
    {
        pausedPanel.SetActive(false);
        isPaused = false;

    }

    public void Retry()
    {
       
        if(saveScore.InputName == true|| score.highScoreObject.gameObject.active == false)
        {
            SceneManager.LoadScene("ReloadScene");
            saveScore.SaveData();
        }
        else
        {
            inputNameText.enabled = true;
        }
    }

    public void PurchaseButton()
    {
        if (!skinManager.skins[skinManager.skinsIndex].gameObject.GetComponent<UnlockedCheck>().unlcocked)
        {
            skinManager.skins[skinManager.skinsIndex].gameObject.GetComponent<UnlockedCheck>().UnlockingSkin();
          
            saveScore.SaveData();
           
        }
        else
        {
            Debug.Log("already unlocked");
           
        }
    }

    public void EquipButton()
    {
        skinManager.currentSkinOwned = skinManager.skins[skinManager.skinsIndex].gameObject.GetComponent<UnlockedCheck>().unlcocked;
       

    }
    public void HighScorePanel()
    {
        highscorePanel.SetActive(true);
        highscoreText.text = score.highScore + " " + "Points!";
        championNameText.text = "Current champion "+ score.championText+ "'s "+ "Highscore: ";
    }

    public void HighScoreQuit()
    {
        highscorePanel.SetActive(false);
    }

    public void HighScoreReset()
    {
        score.highScore = 0;
        score.championText = "";
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
