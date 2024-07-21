using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Score : MonoBehaviour
{
    public int score = 0;
    [SerializeField] TextMeshProUGUI scoreTex;
    [SerializeField] TextMeshProUGUI highScoreText;
    public string championText;

    public GameObject highScoreObject;
    public int endScore;
    public int highScore;
    private SaveScoreScript saveScoreScript;
    private PlayerControl playerControl;
    // Start is called before the first frame update
    void Start()
    {
        saveScoreScript = FindAnyObjectByType<SaveScoreScript>();
        playerControl = FindAnyObjectByType<PlayerControl>();
        saveScoreScript.LoadData();
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("MainScene")){
            scoreTex.text = "Score: " + score;
        }
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
