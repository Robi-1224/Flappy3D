using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Score : MonoBehaviour
{
    public int score = 0;
    public int coinsCollected;
    [SerializeField] TextMeshProUGUI scoreTex;
    [SerializeField] TextMeshProUGUI highScoreText;
    [SerializeField] TextMeshProUGUI currentcoinText;
    public string championText;

    public GameObject highScoreObject;
    public int endScore;
    public int highScore;
    private SaveScoreScript saveScoreScript;
    private PlayerControl playerControl;
    private ObstacleSpawner obstacleSpawner;


    // Start is called before the first frame update
    void Start()
    {
        saveScoreScript = FindAnyObjectByType<SaveScoreScript>();
        playerControl = FindAnyObjectByType<PlayerControl>();
        obstacleSpawner = FindAnyObjectByType<ObstacleSpawner>();
        saveScoreScript.LoadData();
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("MainScene") || SceneManager.GetActiveScene() == SceneManager.GetSceneByName("ReloadScene")){
            scoreTex.text = "Score: " + score;
        }
        currentcoinText.text = "Current coins: " + coinsCollected;
    }
       

    public void ScoreUpdate(int amount)
    {
        score += amount;
       

    }

    public void HighScore()
    {

        if(score > highScore)
        {
            highScore = endScore;
            highScoreObject.SetActive(true);
            playerControl.gameOverHighscoreText.enabled = false;
          
            highScoreText.text = "You have a new HighScore: " + highScore;
        }

        
    }
}
